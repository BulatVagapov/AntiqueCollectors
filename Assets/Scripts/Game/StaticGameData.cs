using System.Collections.Generic;
using UnityEngine;

public static class StaticGameData
{
    public static List<Transform> ActiveItemsAtScene = new();
    public static Dictionary<Collider2D, Item> ColliderItemDictionary = new();
}
