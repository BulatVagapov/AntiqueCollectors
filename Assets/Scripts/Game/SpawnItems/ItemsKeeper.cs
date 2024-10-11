using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ItemsKeeper : MonoBehaviour
{
    private List<Item> vasas = new();
    private List<Item> blueVasas = new();
    private List<Item> grapes = new();
    private List<Item> olives = new();

    private List<Item>[] ItemsPool;
    private int currentFruitListIndex;

    [SerializeField] private ItemsPrefabs itemsPrefabs;
    [SerializeField] private Transform itemsPoolTransform;

    [SerializeField] private int startFruitListsElementQuantity;

    public int[] spawnedIndexes = new int[2] { -1, -1};
    private bool isIndexInArray;

    public List<Item>[] ItemArrayOfLists => ItemsPool;

    public void InintFruitKeeper()
    {
        itemsPrefabs.InitColorDictionary();

        for (int i = 0; i < startFruitListsElementQuantity; i++)
        {
            vasas.Add(GetSetedFruit(ItemType.Vase));
            blueVasas.Add(GetSetedFruit(ItemType.Amfora));
            grapes.Add(GetSetedFruit(ItemType.Grape));
            olives.Add(GetSetedFruit(ItemType.Olive));
        }

        ItemsPool = new List<Item>[] {vasas, blueVasas, grapes, olives};
    }

    private Item GetSetedFruit(ItemType itemType)
    {
        Item currentItem = Instantiate(itemsPrefabs.ItemPrefabsDictionary[itemType]);
        currentItem.InitItem(itemsPoolTransform);
        currentItem.gameObject.SetActive(false);

        return currentItem;
    }

    private void CheckIndexInArray()
    {
        for (int i = 0; i < spawnedIndexes.Length; i++)
        {
            if (currentFruitListIndex == spawnedIndexes[i])
            {
                return;
            }

            if (i == spawnedIndexes.Length - 1 && currentFruitListIndex != spawnedIndexes[i])
                isIndexInArray = false;
        }
    }

    private void AddIndexInarray()
    {
        for (int i = 0; i < spawnedIndexes.Length - 1; i++)
        {
            spawnedIndexes[i] = spawnedIndexes[i + 1];
        }

        spawnedIndexes[spawnedIndexes.Length - 1] = currentFruitListIndex;
    }

    public async Task<Item> GetRandomItem()
    {
        isIndexInArray = true;


        while (isIndexInArray)
        {
            currentFruitListIndex = Random.Range(0, ItemsPool.Length);
            CheckIndexInArray();
            await Task.Delay(10);

        }

        AddIndexInarray();

        return GetItemFromPool(currentFruitListIndex);
    }


    public Item GetItemFromPool(int currentItem)
    {
        for(int i = 0; i < ItemsPool[currentItem].Count; i++)
        {
            if (!ItemsPool[currentItem][i].gameObject.activeSelf)
            {
                return ItemsPool[currentItem][i];
            }

            if(i == ItemsPool[currentItem].Count - 1)
            {
                Item additionalItem = GetSetedFruit(ItemsPool[currentItem][0].ItemType);
                ItemsPool[currentItem].Add(additionalItem);

                return additionalItem;
            }
        }

        return null;
    }
}
