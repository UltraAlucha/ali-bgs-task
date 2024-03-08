using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemData> _availableItems;

    public List<ItemData> AvailableItems => _availableItems;

    public Action OnInventoryChanged;

    public void AddItem(SellingItem item)
    {
        if (item == null) return;

        var itemData = _availableItems.Find(x => x.SellingItem == item);

        if (item == null)
        {
           var newItemData = new ItemData(item);
            
           _availableItems.Add(newItemData);
        }
        else
        {
            itemData.Amount++;
        }

        OnInventoryChanged?.Invoke();
    }

    public SellingItem RemoveItem(SellingItem item)
    {
        var itemData = _availableItems.Find(x => x.SellingItem == item);

        if (item == null)
        {
            return null;
        }
        else
        {
            if(itemData.Amount > 1)
            {
                itemData.Amount--;
            }

            OnInventoryChanged?.Invoke();

            return item;
        }
    }

    public void TransferItem(Inventory inventory, SellingItem item)
    {
        inventory.AddItem(RemoveItem(item));
    }
}

//TODO: Create TransferData Struct if needed
