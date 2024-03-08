using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemData> _availableItems;
    [SerializeField] private bool _removeObjectsOnRunOut;

    public List<ItemData> AvailableItems => _availableItems;

    public Action OnInventoryChanged;

    public void AddItem(SellingItem item)
    {
        if (item == null) return;

        var itemData = _availableItems.Find(x => x.SellingItem == item);

        if (itemData == null)
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

        if (itemData == null)
        {
            return null;
        }
        else
        {
            if(itemData.Amount > 0)
            {
                itemData.Amount--;

                if (_removeObjectsOnRunOut && itemData.Amount == 0)
                {
                    _availableItems.Remove(itemData);
                }
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

public class TransferData
{
    public Inventory From;
    public Inventory To;
    public InventoryViewMode Mode;
}

//TODO: Create TransferData Class if needed
