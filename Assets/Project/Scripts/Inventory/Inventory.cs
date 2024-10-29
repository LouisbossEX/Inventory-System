using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Inventory
{
    public List<InventorySlot> inventorySlots;

    public Inventory(List<InventorySlot> inventorySlots)
    {
        this.inventorySlots = inventorySlots;
    }

    public ItemAddedResult AddItem(Item incomingItem)
    {
        int itemQuantityToAdd = incomingItem.ItemQuantity;

        foreach (var slot in inventorySlots)
        {
            if (!slot.IsItemEqual(incomingItem.ItemData) || slot.IsFull())
                continue;

            int itemQuantityForFullStack = slot.GetQuantityForMaxStack();
            int itemsToAddInSlot = Mathf.Min(itemQuantityForFullStack, itemQuantityToAdd);
            
            slot.AddQuantity(itemsToAddInSlot);
            itemQuantityToAdd -= itemsToAddInSlot;

            if (itemQuantityToAdd == 0)
                break;
        }

        if (itemQuantityToAdd == 0 || inventorySlots.All(x => !x.IsItemEmpty()))
            return new(itemQuantityToAdd);
        
        InventorySlot firstEmptySlot = inventorySlots.First(x => x.IsItemEmpty());
        firstEmptySlot.SetItem(new Item(incomingItem.ItemData, itemQuantityToAdd));

        return new(itemQuantityToAdd);
    }
}