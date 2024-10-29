using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class InventoryRow : MonoBehaviour
{
    [SerializeField] private InventorySlotDisplayer inventorySlotPrefab;

    public void FillRow(int index, int slots, List<InventorySlot> itemList, IObjectResolver resolver)
    {
        for (int i = 0; i < slots; i++)
        {
            int inventorySlotIndex = index + i;
            var inventorySlotDisplayer = Instantiate(inventorySlotPrefab, transform);
            var scopeResolver = resolver.CreateScope(x => x.RegisterInstance(itemList[inventorySlotIndex]));
            scopeResolver.Inject(inventorySlotDisplayer);
        }
    }
}