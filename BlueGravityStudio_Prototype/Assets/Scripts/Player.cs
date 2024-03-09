using UnityEngine;



public class Player : MonoBehaviour
{
    public static Player Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [SerializeField] private Inventory _inventory;

    public Inventory Inventory => _inventory;
}
