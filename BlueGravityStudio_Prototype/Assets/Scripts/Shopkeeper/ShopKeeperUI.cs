using UnityEngine;

public class ShopKeeperUI : MonoBehaviour
{
    [SerializeField] private ShopKeeper _shopKeeper;
    [SerializeField] private GameObject _panel;

    private void Start()
    {
        if (_shopKeeper == null) return;

        _shopKeeper.PlayerEntered += ShowPanel;

        _shopKeeper.PlayerExited += HidePanel;
    }

    void ShowPanel()
    {
        _panel.SetActive(true);
    }

    void HidePanel()
    {
        _panel.SetActive(false);
    }
}
