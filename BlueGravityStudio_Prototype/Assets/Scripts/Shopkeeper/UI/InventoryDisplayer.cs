using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum InventoryViewMode
{
    View, Sell, Buy
}

public class InventoryDisplayer : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private GameObject _panel;

    [SerializeField] private Transform _contentParent;
    [SerializeField] private ItemSlotDisplay _slotPrefab;
    [SerializeField] private InventoryViewMode _viewMode;

    public InventoryViewMode ViewMode
    {
        get { return _viewMode; }
        set { _viewMode = value; }
    }

    private List<ItemSlotDisplay> _slots;
    public List<ItemSlotDisplay> Slots => _slots;

    public Action PanelShown;
    public Action PanelHidden;
    public Action<ItemSlotDisplay> SlotClicked;

    public Action SellRequested;
    public Action BuyRequested;
    public Action ViewRequested;

    private void OnEnable()
    {
        InitializeSlots();
    }

    private void OnDisable()
    {
        Deinitialize();
    }

    public void ShowPanel()
    {
        _panel.SetActive(true);

        PanelShown?.Invoke();
    }

    public void HidePanel()
    {
        _panel.SetActive(false);

        PanelHidden?.Invoke();
    }

    void InitializeSlots()
    {
        foreach (var itemData in _inventory.AvailableItems)
        {
            var slot = Instantiate(_slotPrefab, _contentParent);

            slot.Initialize(itemData);

            slot.SlotButton.onClick.AddListener(ButtonClickedEvent(slot));
        }
    }

    void Deinitialize()
    {
        var childAmount = _contentParent.childCount;

        for (int i = childAmount - 1; i >= 0; i--)
        {
            Destroy(_contentParent.GetChild(i).gameObject);
        }
    }

    private UnityAction ButtonClickedEvent(ItemSlotDisplay slot)
    {
        return () =>
        {
            SlotClicked?.Invoke(slot);
        };
    }
}
