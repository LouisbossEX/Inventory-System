using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

public class HeldItemDisplayer : MonoBehaviour
{
    [FormerlySerializedAs("itemHeldDisplayer")] [SerializeField] private InventorySlotUI itemHeldUI;
    private RectTransform displayerRect;

    private void Awake()
    {
        displayerRect = itemHeldUI.transform as RectTransform;
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
        itemHeldUI.UpdateItem(itemToDisplay.ItemData.ID);
        itemHeldUI.UpdateQuantity(itemToDisplay.ItemQuantity);
    }
}
