using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryItemPop_Equip : InventoryItemPopUp
{
    [SerializeField] private Button _equipButton;

    protected override void ShowDetails(ItemSlotDisplay itemSlot)
    {
        _equipButton.onClick.RemoveAllListeners();

        base.ShowDetails(itemSlot);

        _equipButton.onClick.AddListener(BuyEvent(itemSlot));
    }

    private UnityAction BuyEvent(ItemSlotDisplay itemSlot)
    {
        return () =>
        {
            TransferUtilities.CommitTransfer(Player.Instance.Inventory, Player.Instance.EquipmentInventory, itemSlot.SlotData.SellingItem);

            HideDetails();
        };
    }
}
