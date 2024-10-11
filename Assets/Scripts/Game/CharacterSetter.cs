using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSetter : SingletonBase<CharacterSetter>
{
    private CharacterRole playerRole;

    [SerializeField] private CharacterManager zeus_Player;
    [SerializeField] private CharacterManager zeus_Enemy;
    [SerializeField] private CharacterManager hera_Player;
    [SerializeField] private CharacterManager hera_Enemy;

    public CharacterManager LeftCharacter;
    public CharacterManager RightCharacter;

    [SerializeField] private Route leftRoute;
    [SerializeField] private Route rightRoute;

    [SerializeField] private Transform leftCharacterPlaceTransform;
    [SerializeField] private Transform rightCharacterPlaceTransform;

    [SerializeField] private CollectedItemsCounter leftItemCounter;
    [SerializeField] private CollectedItemsCounter rightItemCounter;

    [SerializeField] private float distanceForChecking;

    [SerializeField] private CharactersSpeed charactersSpeed;

    private GameMode gameMode;

    private bool speedIsChanged;
    private bool characterRoleIsChanged;

    [SerializeField] private Button playerCollectDropButton;

    public event Action<CharacterManager> PlayerIsChanged;

    private void Start()
    {
        charactersSpeed.InitEnemySpeedDictionary();
        SetAllCharacterActive(false);
        SetCharacterActive(false);
        characterRoleIsChanged = true;
        GameManager.Instance.GameCycleStartEvent += OnGameCycleStart;
        GameManager.Instance.GameCycleEndEvent += () => SetCharacterActive(false);
    }

    public void ChangeSpeed(GameMode gameMode)
    {
        this.gameMode = gameMode;
        speedIsChanged = true;
    }

    public void SetPlayerRole(CharacterRole playerRole)
    {
        this.playerRole = playerRole;

        characterRoleIsChanged = true;
    }

    private void SetCharacters()
    {
        if (playerRole.Equals(CharacterRole.Zeus))
        {
            LeftCharacter = zeus_Player;
            RightCharacter = hera_Enemy;
            PlayerIsChanged?.Invoke(LeftCharacter);
        }
        else
        {
            LeftCharacter = zeus_Enemy;
            RightCharacter = hera_Player;
            PlayerIsChanged?.Invoke(RightCharacter);
        }

        SetCharactersSpeed();
    }

    private void ResetCharactersPlace()
    {
        LeftCharacter.transform.position = leftCharacterPlaceTransform.position;
        RightCharacter.transform.position = rightCharacterPlaceTransform.position;
    }

    private void OnGameCycleStart()
    {
        if (characterRoleIsChanged)
        {
            SetCharactersAndItemColectors();
        }else if (speedIsChanged)
        {
            SetCharactersSpeed();
        }

        ResetCharactersPlace();
        SetCharacterActive(true);
    }

    private void SetCharactersAndItemColectors()
    {
        SetCharacters();
        SetItemsCollectors();
    }

    private void SetItemsCollectors()
    {
        leftItemCounter.CharacterType = LeftCharacter.CharacterType;
        rightItemCounter.CharacterType = RightCharacter.CharacterType;
    }

    public void SetCharactersSpeed()
    {
        SetCharacterSpeed(LeftCharacter);
        SetCharacterSpeed(RightCharacter);
        speedIsChanged = false;
    }

    private void SetCharacterSpeed(CharacterManager character)
    {
        if (character.CharacterType.Equals(CharacterType.Player))
        {
            character.Movement.Speed = charactersSpeed.PlayerSpeed;
        }
        else
        {
            character.Movement.Speed = charactersSpeed.EnemySpeedDictionaty[gameMode];
        }
    }


    private void SetCharacterActive(bool activeState)
    {
        LeftCharacter.gameObject.SetActive(activeState);
        RightCharacter.gameObject.SetActive(activeState);
    }

    private void SetAllCharacterActive(bool activeState)
    {
        zeus_Enemy.gameObject.SetActive(activeState);
        zeus_Player.gameObject.SetActive(activeState);
        hera_Enemy.gameObject.SetActive(activeState);
        hera_Player.gameObject.SetActive(activeState);
    }
}
