using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField] private List<ItemData> _availableItems;

    public List<ItemData> AvailableItems => _availableItems;

    public Action PlayerEntered;
    public Action PlayerExited;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out var player))
        {
            OnPlayerEntered();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player))
        {
            OnPlayerExited();
        }
    }
    private void OnPlayerEntered()
    {
        PlayerEntered?.Invoke();
    }

    private void OnPlayerExited()
    {
        PlayerExited?.Invoke();
    }

    public void SellItem(ItemData itemData)
    {
        itemData.Sell();
    }
}
