using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryItemPop_Buy : InventoryItemPopUp
{
    [SerializeField] private Button _buyButton;

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
            itemSlot.SlotData.Sell();

            if (itemSlot.SlotData.Amount <= 0)
            {
                HideDetails();
            }
        };
    }
}
