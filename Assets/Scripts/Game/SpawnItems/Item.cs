using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Item : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private Collider2D collider;
    private Transform parent;
    public float Speed;
    public bool IsCollected = false;
    
    [SerializeField] private ItemType itemType;
    public ItemType ItemType => itemType;
    public SpriteRenderer SpriteRenderer => spriteRenderer;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        StaticGameData.ColliderItemDictionary.Add(collider, this);
    }

    public void InitItem(Transform parent)
    {
        this.parent = parent;
        transform.parent = parent;
    }

    public void SetVelocity(Vector2 direction)
    {
        rigidbody.velocity = -direction * Speed;
    }

    public void CollectItem(Transform newParent)
    {
        IsCollected = true;
        SetVelocity(Vector2.zero);
        collider.enabled = false;
        transform.parent = newParent;
        transform.position = newParent.position;
        spriteRenderer.sortingOrder = 2;
        StaticGameData.ActiveItemsAtScene.Remove(transform);
    }

    public void DropItem()
    {
        collider.enabled = true;
        SetVelocity(transform.up);
        transform.parent = parent;
        spriteRenderer.sortingOrder = 1;
        StaticGameData.ActiveItemsAtScene.Add(transform);
    }

    public void ReturnItemToPool()
    {
        IsCollected = false;
        SetVelocity(Vector2.zero);
        gameObject.SetActive(false);
        StaticGameData.ActiveItemsAtScene.Remove(transform);
    }
}
