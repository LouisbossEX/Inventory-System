using System;
using System.Diagnostics;
using VContainer.Unity;

public class PlayerInventory : IStartable
{
    public Action OnInventorySizeChange;

    private readonly PlayerInventoryConfig config;
    public readonly Inventory inventory;
    
    public Action<Item> OnHeldItemChanged;
    public Action<Item> OnHeldItemUpdated;

    public PlayerInventory(Inventory inventory, PlayerInventoryConfig config)
    {
        this.inventory = inventory;
        this.config = config;
    }

    public void Start()
    {
        AddInitialItems();
    }
    
    [Conditional("UNITY_EDITOR")]
    private void AddInitialItems()
    {
        foreach (var itemWithAmount in config.initialItemsList)
        {
            for (int i = 0; i < itemWithAmount.amount; i++)
            {
                inventory.AddItem(new Item(itemWithAmount.item.Data, 1));
            }
        }
    }
}

public readonly struct ItemAddedResult
{
    public readonly int quantityRemaining;

    public ItemAddedResult(int quantityRemaining)
    {
        this.quantityRemaining = quantityRemaining;
    }
}