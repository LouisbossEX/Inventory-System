using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

[Serializable]
public class DebugMenu
{
    [SerializeField] private TMP_Dropdown itemDropdown;
    [SerializeField] private Button addButton;
    [SerializeField] private TMP_InputField inputField;
    private ItemDataScriptableObject[] allItems;
    private PlayerInventory playerInventory;
    private int itemAmountToAdd = 0;
    private int selectedItemIndex = 0;

    [Inject]
    public void Initialize(ItemDataScriptableObject[] allItems, PlayerInventory playerInventory)
    {
        this.allItems = allItems;
        this.playerInventory = playerInventory;
        
        SetupItems();
        addButton.onClick.AddListener(() => AddItem());
        itemDropdown.onValueChanged.AddListener(x => SelectItem(x));
        inputField.onValueChanged.AddListener(x => SetItemAmount(x));
    }

    public void SetupItems()
    {
        itemDropdown.ClearOptions();

        List<string> itemNames = new List<string>();
        foreach (var item in allItems)
        {
            itemNames.Add(item.Data.ItemName);
        }
        itemDropdown.AddOptions(itemNames);
    }

    public void SelectItem(int index)
    {
        selectedItemIndex = index;
    }

    public void AddItem()
    {
        for (int i = 0; i < itemAmountToAdd; i++)
        {
            playerInventory.inventory.AddItem(new Item(allItems[selectedItemIndex].Data, 1));
        }
    }

    public void SetItemAmount(string amountString)
    {
        addButton.interactable = Int32.TryParse(amountString, out itemAmountToAdd);
    }
}
