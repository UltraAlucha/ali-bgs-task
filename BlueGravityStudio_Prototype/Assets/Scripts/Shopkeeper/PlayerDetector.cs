using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class PlayerDetector : MonoBehaviour
{
    public UnityEvent PlayerEntered;
    public UnityEvent PlayerExited;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerEntered.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerExited.Invoke();
    }
}
