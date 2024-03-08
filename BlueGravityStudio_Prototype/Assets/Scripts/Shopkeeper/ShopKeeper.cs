using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered");

        if(collision.TryGetComponent<Player>(out var player))
        {
            _shopPanel.gameObject.SetActive(player != null);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited");

        if (collision.TryGetComponent<Player>(out var player))
        {
            _shopPanel.gameObject.SetActive(player == null);
        }
    }
}
