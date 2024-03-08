using System;
using static UnityEditor.Progress;

[Serializable]
public class ItemData
{
    public int _amount;

    public SellingItem SellingItem;
    public int Amount
    {
        get => _amount;
        set
        {
            UnityEngine.Debug.Log($"{value} ABA  {_amount}");

            _amount = value;
            ItemSold?.Invoke(this);


            if (_amount == 0)
            {
                ItemRunOut?.Invoke();
            }
        }
    }

    public Action<ItemData> ItemSold;
    public Action ItemRunOut;

    public ItemData(SellingItem sellingItem, int amount = 1)
    {
        SellingItem = sellingItem;
        _amount = amount;
    }
}
