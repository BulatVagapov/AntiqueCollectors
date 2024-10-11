using UnityEngine;

public class ItemToPoolReturner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!StaticGameData.ColliderItemDictionary.ContainsKey(collision)) return;

        StaticGameData.ColliderItemDictionary[collision].ReturnItemToPool();
    }
}
