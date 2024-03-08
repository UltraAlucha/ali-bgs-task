using UnityEngine;

public class ShopKeeperUI : MonoBehaviour
{
    [SerializeField] private ShopKeeper _shopKeeper;
    [SerializeField] private GameObject _panel;

    [SerializeField] private Transform _contentParent;
    [SerializeField] private ItemSlotDisplay _slotPrefab;

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
    }

    void HidePanel()
    {
        _panel.SetActive(false);
    }

    void InitializeSlots()
    {
        foreach (var itemData in _shopKeeper.AvailableItems)
        {
            if (itemData.Amount == 0) continue;

            var slot = Instantiate(_slotPrefab, _contentParent);

            slot.Initialize(itemData);
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
}
