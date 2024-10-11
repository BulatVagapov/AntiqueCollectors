using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collect_DropButtonTextChanger : MonoBehaviour
{
    [SerializeField] private GameObject collectText;
    [SerializeField] private GameObject dropText;
    private CharacterManager playerCharacterManager;

    void Start()
    {
        SetCollectState();
        playerCharacterManager = CharacterSetter.Instance.LeftCharacter;
        CharacterSetter.Instance.PlayerIsChanged += OnPlayerChanged;
        playerCharacterManager.ItemCollector.OnItemCollected += SetDropState;
        playerCharacterManager.ItemCollector.OnItemDroped += SetCollectState;
    }

    private void SetCollectState()
    {
        collectText.SetActive(true);
        dropText.SetActive(false);
    }

    private void SetDropState()
    {
        collectText.SetActive(false);
        dropText.SetActive(true);
    }

    private void OnPlayerChanged(CharacterManager characterManager)
    {
        playerCharacterManager.ItemCollector.OnItemCollected -= SetDropState;
        playerCharacterManager.ItemCollector.OnItemDroped -= SetCollectState;

        playerCharacterManager = characterManager;

        playerCharacterManager.ItemCollector.OnItemCollected += SetDropState;
        playerCharacterManager.ItemCollector.OnItemDroped += SetCollectState;
    }
}
