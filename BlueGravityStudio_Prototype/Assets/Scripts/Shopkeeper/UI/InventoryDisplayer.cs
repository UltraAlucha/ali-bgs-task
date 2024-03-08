using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryDisplayer : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private GameObject _panel;

    [SerializeField] private Transform _contentParent;
    [SerializeField] private ItemSlotDisplay _slotPrefab;

    private List<ItemSlotDisplay> _slots;
    public List<ItemSlotDisplay> Slots => _slots;

    public Action PanelShown;
    public Action PanelHidden;
    public Action<ItemSlotDisplay> SlotClicked;
    private void OnEnable()
    {
        PanelShown?.Invoke();

        InitializeSlots();
    }

    private void OnDisable()
    {
        PanelHidden?.Invoke();

        Deinitialize();
    }

    public void ShowPanel()
    {
        _panel.SetActive(true);
    }

    public void HidePanel()
    {
        _panel.SetActive(false);
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
            SlotClicked.Invoke(slot);
        };
    }
}
