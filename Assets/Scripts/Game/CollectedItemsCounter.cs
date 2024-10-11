using UnityEngine;

public class CollectedItemsCounter : MonoBehaviour
{
    public CharacterType CharacterType;
    
    private CollectedItemKeeper itemKeeper = new();

    public CollectedItemKeeper ItemKeeper => itemKeeper;

    public void DistributeItem(Item collectedItem)
    {
        itemKeeper.IncreaseCountOfCollectedItem(collectedItem.ItemType);
        collectedItem.ReturnItemToPool();
        AudioManager.Instance.PlayAudioSource("Collect");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!StaticGameData.ColliderItemDictionary.ContainsKey(collision)) return;

        if (!StaticGameData.ColliderItemDictionary[collision].IsCollected) return;

        DistributeItem(StaticGameData.ColliderItemDictionary[collision]);
    }
}
