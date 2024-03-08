using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryItemPop_Sell : InventoryItemPopUp
{
    [SerializeField] private Button _sellButton;

    private Inventory _sellInitiator;

    protected override void ShowDetails(ItemSlotDisplay itemSlot)
    {
        _sellButton.onClick.RemoveAllListeners();

        base.ShowDetails(itemSlot);

        _sellButton.onClick.AddListener(BuyEvent(itemSlot));
    }

    public void SetInitiator(Inventory initiator)
    {
        _sellInitiator = initiator;
    }

    private UnityAction BuyEvent(ItemSlotDisplay itemSlot)
    {
        return () =>
        {
            TransferUtilities.CommitTransfer(Player.Instance.Inventory, _sellInitiator, itemSlot.SlotData.SellingItem);

            if (itemSlot.SlotData.Amount <= 0)
            {
                HideDetails();
            }
        };
    }
}
