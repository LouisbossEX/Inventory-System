using System;
using UnityEngine;

public interface IItemDisplayUpdater
{
    void UpdateDisplay(IItemDisplayMutator displayMutator);
}

public struct ItemQuantityDisplayUpdater : IItemDisplayUpdater
{
    private readonly int newQuantity;

    public ItemQuantityDisplayUpdater(int newQuantity)
    {
        this.newQuantity = newQuantity;
    }

    public void UpdateDisplay(IItemDisplayMutator displayMutator)
    {
        displayMutator.UpdateQuantity(newQuantity);
    }
}

public struct ItemChangedDisplayUpdater : IItemDisplayUpdater
{
    private readonly int ID;

    public ItemChangedDisplayUpdater(int ID)
    {
        this.ID = ID;
    }

    public void UpdateDisplay(IItemDisplayMutator displayMutator)
    {
        displayMutator.UpdateItem(ID);
    }
}

public struct ItemMultipleDisplayUpdater : IItemDisplayUpdater
{
    private readonly IItemDisplayUpdater[] displayUpdaters;
    
    public ItemMultipleDisplayUpdater(IItemDisplayUpdater[] displayUpdaters)
    {
        this.displayUpdaters = displayUpdaters;
    }
    
    public void UpdateDisplay(IItemDisplayMutator displayMutator)
    {
        foreach (var updater in displayUpdaters)
        {
            updater.UpdateDisplay(displayMutator);
        }
    }
}

[Serializable]
public class InventorySlot
{
    [SerializeField] private Item item;

    public Action<IItemDisplayUpdater> OnItemChanged;

    public InventorySlot(Item item)
    {
        this.item = item;
    }

    public bool IsItemEmpty() => item == Item.Empty();
    public bool IsDivisible() => GetQuantity() > 1;
    public bool IsFull() => GetMaxQuantity() == GetQuantity();
    public bool IsItemEqual(ItemData itemData) => itemData == item.ItemData;

    public int GetQuantity() => item.ItemQuantity;
    public int GetMaxQuantity() => item.ItemData.MaxStackQuantity;
    public int GetQuantityForMaxStack() => GetMaxQuantity() - GetQuantity();
    public int GetHalf() => Mathf.CeilToInt((float)GetQuantity() / 2);

    public void AddQuantity(int quantity) => ChangeQuantity(GetQuantity() + Mathf.Min(quantity, GetQuantityForMaxStack()));

    public void RemoveQuantity(int quantity) => ChangeQuantity(GetQuantity() - Mathf.Min(quantity, GetQuantity()));

    private void ChangeQuantity(int newQuantity)
    {
        item.ItemQuantity = newQuantity;
        OnItemChanged?.Invoke(new ItemQuantityDisplayUpdater(GetQuantity()));
    }

    public void SetItem(Item item)
    {
        this.item = item;
        OnItemChanged?.Invoke(new ItemMultipleDisplayUpdater(new IItemDisplayUpdater[]
        {
            new ItemQuantityDisplayUpdater(GetQuantity()),
            new ItemChangedDisplayUpdater(item.ItemData.ID)
        }));
    }

    public void AddItemChangedListener(Action<IItemDisplayUpdater> action)
    {
        OnItemChanged += action;
        action?.Invoke(new ItemMultipleDisplayUpdater(new IItemDisplayUpdater[]
        {
            new ItemQuantityDisplayUpdater(GetQuantity()),
            new ItemChangedDisplayUpdater(item.ItemData.ID)
        }));
    }
}