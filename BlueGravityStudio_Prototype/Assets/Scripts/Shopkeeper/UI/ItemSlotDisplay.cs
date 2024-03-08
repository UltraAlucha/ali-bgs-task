using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotDisplay : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _amountText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private GameObject _priceIndicator;
    [SerializeField] private GameObject _amountIndicator;
    [SerializeField] private GameObject _soldIndicator;
    [SerializeField] private Button _slotButton;

    public void Initialize(ItemData itemData)
    {
        UpdateAmount(itemData);

        var itemSO = itemData.SellingItem;

        _iconImage.sprite = itemSO.DisplayIcon;

        _priceText.text = $"{itemSO.Price}";

        itemData.ItemSold += UpdateAmount;

        itemData.ItemRunOut += CheckAvailability;

        _slotButton.onClick.AddListener(InternalSell);

        void InternalSell()
        {
            itemData.Sell();

            itemData.ItemRunOut += () =>
            {
                _slotButton.onClick.RemoveListener(InternalSell);
            };
        }
    }

    void UpdateAmount(ItemData itemData)
    {
        _amountText.text = $"x{itemData.Amount}";
    }

    void CheckAvailability()
    {
        _amountIndicator.SetActive(false);
        _priceIndicator.SetActive(false);
        _soldIndicator.SetActive(true);
    }
}
