using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class InventoryScope : LifetimeScope
{
    [SerializeField] private PlayerInventoryConfig playerInventoryConfig;
    [SerializeField] private ItemDataScriptableObject[] allItems;
    [SerializeField] private Sprite emptySprite;
    [SerializeField] private DebugMenu debugMenu = new();
    
    protected override void Configure(IContainerBuilder builder)
    {
        List<InventorySlot> inventorySlots = new();
        for (int i = 0; i < playerInventoryConfig.InventoryLength; i++)
        {
            inventorySlots.Add(new InventorySlot(Item.Empty()));
        }

        Inventory inventory = new Inventory(inventorySlots);
        var spritesDictionary = allItems.ToDictionary(x => x.Data.ID, x => x.Sprite);
        spritesDictionary.Add(-1, emptySprite);
        
        builder.RegisterInstance(allItems);
        builder.RegisterInstance(inventory);
        builder.RegisterInstance(playerInventoryConfig);
        builder.RegisterInstance(Item.Empty());
        builder.Register<InventorySlot>(Lifetime.Transient);
        builder.Register<ItemSpriteFactory>(Lifetime.Singleton)
            .WithParameter("sprites", spritesDictionary);
        builder.RegisterComponent(debugMenu);
        
        builder.RegisterEntryPoint<PlayerInventory>().AsSelf();
    }
}