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
    [SerializeField] private EquipmentInventory _equipmentInventory;

    public Inventory Inventory => _inventory;
    public EquipmentInventory EquipmentInventory => _equipmentInventory;
}
