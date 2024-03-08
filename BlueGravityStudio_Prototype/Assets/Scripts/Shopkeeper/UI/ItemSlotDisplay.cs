using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemSlotDisplay : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _amountText;
    [SerializeField] private TMP_Text _priceText;

    public void Initialize(ItemData itemData)
    {
        UpdateAmount(itemData);

        var itemSO = itemData.SellingItem;

        _iconImage.sprite = itemSO.DisplayIcon;

        _priceText.text = $"{itemSO.Price}";

        itemData.ItemSold += UpdateAmount;

        itemData.ItemRunOut += UpdatePriceText;
    }

    void UpdateAmount(ItemData itemData)
    {
        _amountText.text = $"x{itemData.Amount}";
    }

    void UpdatePriceText()
    {
        _priceText.text = $"SOLD";
    }
}
