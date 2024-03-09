using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource_", menuName = "ResourceSO")]
public class Resource : ScriptableObject
{
    [SerializeField] private int _amount;
    public Sprite Icon;

    public Action AmountChanged;

    public int Amount
    {
        get
        {
            return _amount;
        }

        set
        {
            if (value < 0) value = 0;

            _amount = value;

            AmountChanged?.Invoke();
        }
    }

    public void AddAmount(int amount)
    {
        Amount += amount; 
    }
}
