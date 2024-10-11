using System;
using UnityEngine;

public abstract class AbstractInput : MonoBehaviour
{
    protected Vector2 direction;
    public Vector2 Direction => direction;

    public event Action CollectItemEvent;
    public event Action DropItemEvent;

    protected void OnCollectItem()
    {
        CollectItemEvent?.Invoke();
    }

    protected void OnDropItem()
    {
        DropItemEvent?.Invoke();
    }
}
