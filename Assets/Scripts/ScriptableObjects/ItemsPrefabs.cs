using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsPrefabs", menuName = "ScriptableObjects/ItemsPrefabs")]

public class ItemsPrefabs : ScriptableObject
{
    public ItemType[] ItemYypes;
    public Item[] Items;

    public Dictionary<ItemType, Item> ItemPrefabsDictionary;

    public void InitColorDictionary()
    {
        ItemPrefabsDictionary = new Dictionary<ItemType, Item>();

        for (int i = 0; i < ItemYypes.Length; i++)
        {
            ItemPrefabsDictionary.Add(ItemYypes[i], Items[i]);
        }
    }
}
