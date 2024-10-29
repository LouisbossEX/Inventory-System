using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class PlayerInventoryDisplayer : MonoBehaviour
{
    [SerializeField] private InventoryRow inventoryRowPrefab;
    [SerializeField] private Transform hotbarTransform;
    [SerializeField] private Transform inventoryTransform;

    private CanvasGroup canvasGroup;
    
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    [Inject]
    public void Initialize(PlayerInventoryConfig config, PlayerInventory playerInventory, IObjectResolver resolver)
    {
        int hotbarSlotsLeft = Mathf.Min(config.HotbarSlots, config.InventoryLength);
        
        Fill(0, hotbarSlotsLeft, config.HotbarSlots, 
            config.HotbarRowLength, playerInventory.inventory.inventorySlots, resolver, hotbarTransform);

        int slotsLeft = config.InventoryLength - Mathf.Min(config.HotbarSlots, config.InventoryLength);
        if (slotsLeft == 0)
            return;
        
        int hotbarLastItemIndex = Mathf.Min(config.HotbarSlots, config.InventoryLength);

        Fill(hotbarLastItemIndex, slotsLeft, config.InventoryLength - config.HotbarSlots, 
            config.InventoryRowLength, playerInventory.inventory.inventorySlots, resolver, inventoryTransform);
    }

    private void Fill(int initialItemIndex, int slotsLeft, int inventoryLength, int rowLength, 
        List<InventorySlot> inventorySlots, IObjectResolver resolver, Transform rowDisplayHolder)
    {
        for (int i = 0; i < Mathf.Ceil((float)(inventoryLength)/rowLength); i++)
        {
            int slotsInRow = Mathf.Min(rowLength, Mathf.Min(rowLength, slotsLeft));
            slotsLeft -= slotsInRow;
            
            InventoryRow inventoryRow = Instantiate(inventoryRowPrefab, rowDisplayHolder);
            inventoryRow.FillRow(initialItemIndex + i * slotsInRow, slotsInRow, inventorySlots, resolver);
            
            if (slotsLeft == 0)
                break;
        }
    }

    private void Start()
    {
        StartCoroutine(RebuildLayout());
    }

    public IEnumerator RebuildLayout()
    {
        canvasGroup.alpha = 0f;
        yield return new WaitForSeconds(0.1f);
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
        yield return new WaitForSeconds(0.1f);
        canvasGroup.alpha = 1f;
    }
}