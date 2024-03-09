using System;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInventory : Inventory
{
    [SerializeField] private Inventory _playerInventory;

    public List<EquipmentSlot> InventorySlots = new();

    public Action<SellingItem> OnNewItemEquip;

    [Serializable]
    public class EquipmentSlot
    {
        public ItemData ItemData;
        public EquipmentType EquipmentType;
    }

    private void Awake()
    {
        InitializeEquipments();
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

        SetEquipment(item);

        OnNewItemEquip?.Invoke(item);

        return itemData;
    }

    private void SetEquipment(SellingItem item)
    {
        var equipmentSlot = InventorySlots.Find(x => x.EquipmentType == item.EquipmentType);

        equipmentSlot?.ItemData.SetData(item);
    }

    void InitializeEquipments()
    {
        foreach (var item in AvailableItems)
        {
            SetEquipment(item.SellingItem);
        }
    }

    public override SellingItem RemoveItem(SellingItem item)
    {
        base.RemoveItem(item);

        return item;
    }
}
