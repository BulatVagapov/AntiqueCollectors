using UnityEngine;
using UnityEngine.UI;

public class RulesScreen : MonoBehaviour
{
    [SerializeField] private Button leftCharacterButton;
    [SerializeField] private Button rightCharacterButton;
    [SerializeField] private Button okButton;
    [SerializeField] private Button backButton;

    [SerializeField] private Transform itsYouTextTransforn;
    [SerializeField] private Transform yourEnemyTextTransforn;

    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject selectGameModeScreen;

    [SerializeField] private Transform leftTextTransform;
    [SerializeField] private Transform rightTextTransform;

    void Start()
    {

        leftCharacterButton.onClick.AddListener(OnLeftCharacterButtonClick);
        rightCharacterButton.onClick.AddListener(OnRightCharacterButtonClick);
        okButton.onClick.AddListener(OnOkButtonClick);
        backButton.onClick.AddListener(OnBackButtonClick);

        gameObject.SetActive(false);
    }

    private void OnLeftCharacterButtonClick()
    {
        itsYouTextTransforn.position = leftTextTransform.position;
        yourEnemyTextTransforn.position = rightTextTransform.position;
        CharacterSetter.Instance.SetPlayerRole(CharacterRole.Zeus);
    }

    private void OnRightCharacterButtonClick()
    {
        itsYouTextTransforn.position = rightTextTransform.position;
        yourEnemyTextTransforn.position = leftTextTransform.position;
        CharacterSetter.Instance.SetPlayerRole(CharacterRole.Hera);
    }

    private void OnOkButtonClick()
    {
        GameManager.Instance.OnGameCycleStart();
        gameObject.SetActive(false);
        gameScreen.SetActive(true);
    }

    private void OnBackButtonClick()
    {
        gameObject.SetActive(false);
        selectGameModeScreen.SetActive(true);
    }
}
