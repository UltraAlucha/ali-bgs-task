using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPopUpManager : MonoBehaviour
{
    [SerializeField] protected InventoryDisplayer _inventoryDisplayer;
    [SerializeField] public List<ViewSocket> _sockets = new();

    [Serializable]
    public struct ViewSocket
    {
        public InventoryViewMode ViewMode;
        public InventoryItemPopUp PopUp;
    }

    private void Start()
    {
        _inventoryDisplayer.PanelShown += ActivateProperPopUp;

        _inventoryDisplayer.PanelHidden += DeactivateProperPopUp;
    }

    private void ActivateProperPopUp()
    {
        Debug.Log(_inventoryDisplayer.ViewMode);

        var properPopUp = _sockets.Find(x => x.ViewMode == _inventoryDisplayer.ViewMode);

        properPopUp.PopUp.Activate();
    }

    private void DeactivateProperPopUp()
    {
        var properPopUp = _sockets.Find(x => x.ViewMode == _inventoryDisplayer.ViewMode);

        if (properPopUp.PopUp == null) return;

        properPopUp.PopUp.Deactivate();
    }
}
