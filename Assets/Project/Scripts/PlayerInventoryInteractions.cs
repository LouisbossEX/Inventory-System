using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

public class PlayerInventoryInteractions : MonoBehaviour, IPointerClickHandler
{
    private InventorySlot inventorySlot;
    private PlayerInventory playerInventory;

    [Inject]
    public void Initialize(PlayerInventory playerInventory, InventorySlot inventorySlot)
    {
        this.playerInventory = playerInventory;
        this.inventorySlot = inventorySlot;
    }
    
    private void HoldItem()
    {
        
    }
    
    private void SplitStack()
    {
        
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            SplitStack();
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            HoldItem();
        }
    }
}