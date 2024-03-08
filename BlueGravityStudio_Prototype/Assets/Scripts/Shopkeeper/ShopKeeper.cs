using System;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
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
}
