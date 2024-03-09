using System;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInventory : Inventory
{
    [SerializeField] private Inventory _playerInventory;
    public List<EquipmentSlot> InventorySlots = new();

    [Serializable]
    public class EquipmentSlot
    {
        public ItemData ItemData;
        public EquipmentType EquipmentType;

    }

    public override ItemData AddItem(SellingItem item)
    {
        var oldItem = _availableItems.Find(x => x.SellingItem.EquipmentType == item.EquipmentType);

        if (oldItem != null)
        {
            RemoveItem(oldItem.SellingItem);

            TransferUtilities.CommitTransfer(this, _playerInventory, oldItem.SellingItem);
        }

        var itemData = base.AddItem(item);

        var equipmentSlot = InventorySlots.Find(x => x.EquipmentType == item.EquipmentType);

        if (equipmentSlot != null)
        {
            equipmentSlot.ItemData.SetData(item);
        }

        return itemData;
    }

    public override SellingItem RemoveItem(SellingItem item)
    {
        base.RemoveItem(item);

        return item;
    }
}
