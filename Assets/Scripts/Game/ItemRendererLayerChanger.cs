using UnityEngine;

public class ItemRendererLayerChanger : MonoBehaviour
{
    [SerializeField] private int sortingLayerId;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!StaticGameData.ColliderItemDictionary.ContainsKey(collision)) return;

        if (StaticGameData.ColliderItemDictionary[collision].IsCollected) return;

        StaticGameData.ColliderItemDictionary[collision].SpriteRenderer.sortingOrder = sortingLayerId;
    }
}
