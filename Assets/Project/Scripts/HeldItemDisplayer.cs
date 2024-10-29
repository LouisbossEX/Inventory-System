using UnityEngine;
using VContainer;

public class HeldItemDisplayer : MonoBehaviour
{
    [SerializeField] private InventorySlotDisplayer itemHeldDisplayer;
    private RectTransform displayerRect;

    private void Awake()
    {
        displayerRect = itemHeldDisplayer.transform as RectTransform;
    }

    [Inject]
    public void Initialize(PlayerInventory playerInventory)
    {
        playerInventory.OnHeldItemChanged += UpdateHeldItem;
    }
    
    void Update()
    {
        displayerRect.position = Input.mousePosition;
    }

    private void UpdateHeldItem(Item itemToDisplay)
    {
        itemHeldDisplayer.UpdateItem(itemToDisplay.ItemData.ID);
        itemHeldDisplayer.UpdateQuantity(itemToDisplay.ItemQuantity);
    }
}
