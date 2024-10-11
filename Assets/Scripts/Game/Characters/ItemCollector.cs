using System;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Transform handTransform;

    public Item PossibleToCollectItem;
    public Item CollectedItem;

    public Transform HandTransform => handTransform;

    public event Action OnItemCollected;
    public event Action OnItemDroped;

    private void Start()
    {
        GameManager.Instance.GameCycleEndEvent += DropCollectedItem;
    }

    public void CollectPossibleItem()
    {
        if (PossibleToCollectItem == null) return;

        CollectedItem = PossibleToCollectItem;
        PossibleToCollectItem.CollectItem(handTransform);
        PossibleToCollectItem = null;
        OnItemCollected?.Invoke();
        AudioManager.Instance.PlayAudioSource("PickUp");
    }

    public void DropCollectedItem()
    {
        if (CollectedItem == null) return;

        CollectedItem.DropItem();
        CollectedItem = null;
        OnItemDroped?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!StaticGameData.ColliderItemDictionary.ContainsKey(collision)) return;

        if (PossibleToCollectItem != null || CollectedItem != null) return;

        PossibleToCollectItem = StaticGameData.ColliderItemDictionary[collision];
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!StaticGameData.ColliderItemDictionary.ContainsKey(collision)) return;

        if (PossibleToCollectItem != StaticGameData.ColliderItemDictionary[collision]) return;

        PossibleToCollectItem = null;
    }

    private void OnDestroy()
    {
        GameManager.Instance.GameCycleEndEvent -= DropCollectedItem;
    }
}
