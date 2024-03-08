using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotDisplay : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _amountText;
    [SerializeField] private TMP_Text _priceText;

    public void Initialize(ItemData itemData)
    {
        _amountText.text = $"x{itemData.Amount}";

        var itemSO = itemData.SellingItem;

        _iconImage.sprite = itemSO.DisplayIcon;

        _priceText.text = $"{itemSO.Price}";
    }
}
