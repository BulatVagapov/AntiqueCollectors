using System;
using System.Collections.Generic;
using UnityEngine;

public class WinnerDeterminator : SingletonBase<WinnerDeterminator>
{
    [SerializeField] private CollectedItemsCounter[] itemsCounters;

    private int playerItemsTotalQuantity;
    private int enemyItemsTotalQuantity;

    private CharacterType winnerTipe;

    public event Action<CollectedItemsCounter[], CharacterType> WinnerIsDeterminated;

    private void Start()
    {
        GameManager.Instance.GameCycleStartEvent += OnStartGameCycle;
        GameManager.Instance.GameCycleEndEvent += OnGameCycleEnd;
    }

    private void OnStartGameCycle()
    {
        for (int i = 0; i < itemsCounters.Length; i++)
        {
            itemsCounters[i].ItemKeeper.ResetCountOfCollectedItemsByType();
        }
    }

    private void OnGameCycleEnd()
    {
        for(int i = 0; i < itemsCounters.Length; i++)
        {
            if (itemsCounters[i].CharacterType.Equals(CharacterType.Player))
            {
                CountTotalQuantity(ref playerItemsTotalQuantity, itemsCounters[i].ItemKeeper.CountOfCollectedItemsByType);
            }
            else
            {
                CountTotalQuantity(ref enemyItemsTotalQuantity, itemsCounters[i].ItemKeeper.CountOfCollectedItemsByType);
            }
        }

        if(playerItemsTotalQuantity >= enemyItemsTotalQuantity)
        {
            winnerTipe = CharacterType.Player;
        }
        else
        {
            winnerTipe = CharacterType.Enemy;
        }

        WinnerIsDeterminated?.Invoke(itemsCounters, winnerTipe);
    }

    private void CountTotalQuantity(ref int totalNumber, Dictionary<ItemType, int> dictionaryOfCollectedItems)
    {
        totalNumber += dictionaryOfCollectedItems[ItemType.Amfora];
        totalNumber += dictionaryOfCollectedItems[ItemType.Vase];
        totalNumber += dictionaryOfCollectedItems[ItemType.Grape];
        totalNumber += dictionaryOfCollectedItems[ItemType.Olive];
    }
}
