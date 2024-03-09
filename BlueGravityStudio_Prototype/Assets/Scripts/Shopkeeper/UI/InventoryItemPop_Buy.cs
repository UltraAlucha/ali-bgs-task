using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryItemPop_Buy : InventoryItemPopUp
{
    [SerializeField] private Button _buyButton;
    [SerializeField] private Resource _payWith;

    protected override void ShowDetails(ItemSlotDisplay itemSlot)
    {
        _buyButton.onClick.RemoveAllListeners();

        base.ShowDetails(itemSlot);

        _buyButton.onClick.AddListener(BuyEvent(itemSlot));
    }

    private UnityAction BuyEvent(ItemSlotDisplay itemSlot)
    {
        return () =>
        {
            Debug.Log($"{_payWith.Amount} | {itemSlot.SlotData.SellingItem.Price}");

            if (_payWith.Amount < itemSlot.SlotData.SellingItem.Price) return;

            _payWith.Amount -= itemSlot.SlotData.SellingItem.Price;

            Debug.Log($"PURCHASED");

            TransferUtilities.CommitTransfer(_inventoryDisplayer.Inventory, Player.Instance.Inventory, itemSlot.SlotData.SellingItem);

            if (itemSlot.SlotData.Amount <= 0)
            {
                HideDetails();
            }
        };
    }
}
