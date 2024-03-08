using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemData> _availableItems;

    public List<ItemData> AvailableItems => _availableItems;


}
