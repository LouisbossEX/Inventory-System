using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlayerInventoryConfig : ScriptableObject
{
    public int InventoryLength = 36;
    public int HotbarRowLength = 9;
    public int InventoryRowLength = 9;
    /// <summary>
    /// This slots only determine items from the inventory will be shown in the hotbar, this doesn't add new slots to the inventory
    /// </summary>
    public int HotbarSlots = 9;
    
    public List<ItemWithAmount> initialItemsList;
}

[Serializable]
public struct ItemWithAmount
{
    public ItemDataScriptableObject item;
    public int amount;
}