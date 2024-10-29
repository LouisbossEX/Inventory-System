using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public interface IItemDisplayMutator
{
    void UpdateItem(int ID);
    void UpdateQuantity(int quantity);
}

public class InventorySlotDisplayer : MonoBehaviour, IItemDisplayMutator
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemCountText;
    [SerializeField] private Image highlightImage;
    private ItemSpriteFactory itemSpriteFactory;
    
    [Inject]
    public void Initialize(InventorySlot inventorySlot, ItemSpriteFactory itemSpriteFactory)
    {
        this.itemSpriteFactory = itemSpriteFactory;
        inventorySlot.AddItemChangedListener(OnItemChanged);
    }

    private void OnItemChanged(IItemDisplayUpdater updater)
    {
        updater.UpdateDisplay(this);
    }

    public void UpdateItem(int ID)
    {
        Sprite itemSprite = itemSpriteFactory.GetSprite(ID);
        itemImage.color = new Color(1,1,1,itemSprite == null ? 0 : 1);
        itemImage.sprite = itemSprite;
    }

    public void UpdateQuantity(int quantity)
    {
        itemCountText.text = quantity <= 1 ? "" : quantity.ToString();
    }
    
    public void SetHighlightState(bool activeState)
    {
        highlightImage.color = new Color(1,1,1, activeState ? 0.5f : 0f);
    }
}
