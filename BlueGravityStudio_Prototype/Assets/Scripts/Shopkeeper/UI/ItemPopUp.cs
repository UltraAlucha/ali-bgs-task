using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemPopUp : MonoBehaviour
{
    [SerializeField] private ShopKeeperUI _shopKeeperUI;
    [SerializeField] private TMP_Text _displayText;
    [SerializeField] private Image _displayImage;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private GameObject _body;
    [SerializeField] private Button _buyButton;

    private void Awake()
    {
        _shopKeeperUI.PanelHidden += HideDetails;

        _shopKeeperUI.SlotClicked += ShowDetails;
    }

    private void ShowDetails(ItemSlotDisplay itemSlot)
    {
        _buyButton.onClick.RemoveAllListeners();

        _body.SetActive(true);

        _displayText.text = itemSlot.SlotData.SellingItem.DisplayName;

        _priceText.text = itemSlot.SlotData.SellingItem.Price.ToString();

        _displayImage.sprite = itemSlot.SlotData.SellingItem.DisplayIcon;

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

    private void HideDetails()
    {
        _body.SetActive(false);
    }
}
