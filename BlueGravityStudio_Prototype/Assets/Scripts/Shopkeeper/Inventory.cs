using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] protected List<ItemData> _availableItems;

    public List<ItemData> AvailableItems => _availableItems;

    public Action OnInventoryChanged;

    public virtual ItemData AddItem(SellingItem item)
    {
        if (item == null) return null;

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

        return itemData;
    }

    public virtual SellingItem RemoveItem(SellingItem item)
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

                if ( itemData.Amount == 0)
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
