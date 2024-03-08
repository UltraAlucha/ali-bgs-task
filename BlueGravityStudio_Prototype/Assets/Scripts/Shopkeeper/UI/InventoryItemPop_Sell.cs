using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryItemPop_Sell : InventoryItemPopUp
{
    [SerializeField] private Button _sellButton;

    protected override void ShowDetails(ItemSlotDisplay itemSlot)
    {
        _sellButton.onClick.RemoveAllListeners();

        base.ShowDetails(itemSlot);

        _sellButton.onClick.AddListener(BuyEvent(itemSlot));
    }

    private UnityAction BuyEvent(ItemSlotDisplay itemSlot)
    {
        return () =>
        {
            // CHANGE HERE
            itemSlot.SlotData.Sell();

            if (itemSlot.SlotData.Amount <= 0)
            {
                HideDetails();
            }
        };
    }
}
