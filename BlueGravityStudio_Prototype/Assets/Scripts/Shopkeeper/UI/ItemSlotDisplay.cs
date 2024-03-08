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

    private ItemData _slotData;

    public ItemData SlotData => _slotData;

    public Button SlotButton => _slotButton;

    public void Initialize(ItemData itemData)
    {
        _slotData = itemData;

        var itemSO = _slotData.SellingItem;

        _iconImage.sprite = itemSO.DisplayIcon;

        if (_slotData.Amount == 0)
        {
            CheckAvailability();

            return;
        }

        UpdateAmount(_slotData);

        _priceText.text = $"{itemSO.Price}";

        _slotData.ItemSold += UpdateAmount;

        _slotData.ItemSold += CheckAvailability;
    }

    private void OnDestroy()
    {
        _slotData.ItemSold -= UpdateAmount;

        _slotData.ItemSold -= CheckAvailability;
    }

    void UpdateAmount(ItemData itemData)
    {
        _amountText.text = $"x{itemData.Amount}";
    }

    void CheckAvailability(ItemData itemData = null)
    {
        if (_slotData.Amount > 0) return;

        _amountIndicator.SetActive(false);
        _priceIndicator.SetActive(false);
        _soldIndicator.SetActive(true);
    }
}
