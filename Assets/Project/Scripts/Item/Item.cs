using System;
using UnityEngine;

[Serializable]
public struct Item
{
    public ItemData ItemData;
    public int ItemQuantity;

    public static Item Empty() => new Item(ItemData.NoItem, 1);

    public Item(ItemData itemData, int itemQuantity)
    {
        this.ItemData = itemData;
        this.ItemQuantity = Mathf.Min(itemQuantity, itemData.MaxStackQuantity);
    }
    
    public static bool operator ==(Item a, Item b)
    {
        return a.ItemData == b.ItemData && a.ItemQuantity == b.ItemQuantity;
    }
    
    public static bool operator !=(Item a, Item b)
    {
        return !(a == b);
    }
}