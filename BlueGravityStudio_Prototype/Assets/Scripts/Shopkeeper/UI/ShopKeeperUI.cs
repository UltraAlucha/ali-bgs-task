using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopKeeperUI : MonoBehaviour
{
    [SerializeField] private ShopKeeper _shopKeeper;
    [SerializeField] private GameObject _panel;

    [SerializeField] private Transform _contentParent;
    [SerializeField] private ItemSlotDisplay _slotPrefab;

    private List<ItemSlotDisplay> _slots;

    public List<ItemSlotDisplay> Slots => _slots;


    public Action PanelShown;
    public Action PanelHidden;
    public Action<ItemSlotDisplay> SlotClicked;

    private void Start()
    {
        if (_shopKeeper == null) return;

        _shopKeeper.PlayerEntered += ShowPanel;

        _shopKeeper.PlayerExited += HidePanel;

        _shopKeeper.PlayerEntered += InitializeSlots;

        _shopKeeper.PlayerExited += Deinitialize;
    }

    void ShowPanel()
    {
        _panel.SetActive(true);

        PanelShown?.Invoke();
    }

    void HidePanel()
    {
        _panel.SetActive(false);

        PanelHidden?.Invoke();
    }

    void InitializeSlots()
    {
        foreach (var itemData in _shopKeeper.AvailableItems)
        {
            var slot = Instantiate(_slotPrefab, _contentParent);

            slot.Initialize(itemData);

            slot.SlotButton.onClick.AddListener(ButtonClickedEvent(slot));
        }
    }

    private UnityAction ButtonClickedEvent(ItemSlotDisplay slot)
    {
        return () =>
        {
            SlotClicked.Invoke(slot);
        };
    }

    void Deinitialize()
    {
        var childAmount = _contentParent.childCount;

        for (int i = childAmount - 1; i >= 0; i--)
        {
            Destroy(_contentParent.GetChild(i).gameObject);
        }
    }
}
