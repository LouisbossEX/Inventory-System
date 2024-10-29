public class InventoryManager
{
    public Item RemoveHalfTheItemAmount()
    {
        /*
        if (!item.IsDivisible)
            return item;
        
        int amountToReturn = Mathf.CeilToInt((float)item.ItemQuantity / 2);
        item.ItemQuantity -= amountToReturn;
        OnItemUpdated?.Invoke(item);
        return new Item(item.ItemData, amountToReturn);
        */
        return Item.Empty();
    }
    
    public Item RemoveItemAmount(int amount)
    {
        /*
        Item itemInSlot = new Item(item.ItemData, item.ItemQuantity);
        
        item.ItemQuantity -= amount;

        if (item.ItemQuantity <= 0)
        {
            item = Item.Empty();
            OnItemChanged?.Invoke(item);
        }
        else
        {
            OnItemUpdated?.Invoke(item);
        }

        itemInSlot.ItemQuantity = amount;
        return itemInSlot;
        */
        return Item.Empty();
    }

    public Item AddItem(Item itemToAdd)
    {
        /*
        Item itemInSlot = item;
        
        if (item.ItemData.MaxStackQuantity <= 1 || itemToAdd.ItemData.MaxStackQuantity <= 1 || itemToAdd.ItemData.ID != item.ItemData.ID)
        {
            item = itemToAdd;
            OnItemChanged?.Invoke(item);
            return itemInSlot;
        }
        else if (item.ItemQuantity == item.ItemData.MaxStackQuantity)
        {
            item = itemToAdd;
            OnItemChanged?.Invoke(item);
            return itemInSlot;
        }
        else
        {
            int newStackAmount = item.ItemQuantity + itemToAdd.ItemQuantity;

            if (newStackAmount > item.ItemData.MaxStackQuantity)
            {
                item.ItemQuantity = item.ItemData.MaxStackQuantity;
                itemToAdd.ItemQuantity -= (newStackAmount - item.ItemData.MaxStackQuantity);
                OnItemUpdated?.Invoke(item);
                return itemToAdd;
            }
            else
            {
                item.ItemQuantity += itemToAdd.ItemQuantity;
                OnItemUpdated?.Invoke(item);

                Item itemToReturn = Item.Empty();
                return itemToReturn;
            }
        }
        */
        return Item.Empty();
    }
    
    /*
    public void HoldItem(Item itemToHold)
    {
        heldItem.SetItem(itemToHold);
        OnHeldItemChanged?.Invoke(itemToHold);
    }

    public Item RemoveHeldItem(bool onlyOneItem)
    {
        return Item.Empty();
    }
    */
}