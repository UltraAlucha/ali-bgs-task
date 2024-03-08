using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemPopUp : MonoBehaviour
{
    [SerializeField] protected InventoryDisplayer _inventoryDisplayer;
    [SerializeField] protected TMP_Text _displayText;
    [SerializeField] protected Image _displayImage;
    [SerializeField] protected TMP_Text _priceText;
    [SerializeField] protected GameObject _body;

    public void Activate()
    {
        _inventoryDisplayer.PanelHidden += HideDetails;

        _inventoryDisplayer.SlotClicked += ShowDetails;
    }

    public void Deactivate()
    {
        _inventoryDisplayer.PanelHidden -= HideDetails;

        _inventoryDisplayer.SlotClicked -= ShowDetails;
    }

    protected virtual void ShowDetails(ItemSlotDisplay itemSlot)
    {
        _body.SetActive(true);

        _displayText.text = itemSlot.SlotData.SellingItem.DisplayName;

        _priceText.text = itemSlot.SlotData.SellingItem.Price.ToString();

        _displayImage.sprite = itemSlot.SlotData.SellingItem.DisplayIcon;
    }

    protected void HideDetails()
    {
        _body.SetActive(false);
    }
}
