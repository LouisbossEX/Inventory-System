using System;

[Serializable]
public class ItemData
{
    public int ID;
    public int MaxStackQuantity;

    public static readonly ItemData NoItem = new ItemData(-1, 1);
    
    public ItemData(int id, int maxStackQuantity)
    {
        ID = id;
        MaxStackQuantity = maxStackQuantity;
    }

    public static bool operator ==(ItemData a, ItemData b)
    {
        return a is not null && b is not null && a.ID == b.ID;
    }

    public static bool operator !=(ItemData a, ItemData b)
    {
        return !(a == b);
    }
}