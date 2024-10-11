using System;
using System.Collections.Generic;

public class CollectedItemKeeper
{
    private Dictionary<ItemType, int> countOfCollectedItemsByType = new Dictionary<ItemType, int>()
                                                                        {
                                                                            { ItemType.Amfora, 0 },
                                                                            { ItemType.Vase, 0 },
                                                                            { ItemType.Grape, 0 },
                                                                            { ItemType.Olive, 0 }
                                                                        };

    public Dictionary<ItemType, int> CountOfCollectedItemsByType => countOfCollectedItemsByType;

    public void IncreaseCountOfCollectedItem(ItemType collectedItemType)
    {
        if (!countOfCollectedItemsByType.ContainsKey(collectedItemType))
        {
            countOfCollectedItemsByType.Add(collectedItemType, 1);
        }
        else
        {
            countOfCollectedItemsByType[collectedItemType]++;
        }
    }
    
    public void ResetCountOfCollectedItemsByType()
    {
        for(int i = 0; i < Enum.GetValues(typeof(ItemType)).Length; i++)
        {
            if (countOfCollectedItemsByType.ContainsKey((ItemType)i));
            {
                countOfCollectedItemsByType[(ItemType)i] = 0;
            }
        }
    }
}
