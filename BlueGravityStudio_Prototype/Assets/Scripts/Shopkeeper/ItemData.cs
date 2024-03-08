using System;

[Serializable]
public class ItemData
{
    public SellingItem SellingItem;
    public int Amount;

    public Action<ItemData> ItemSold;
    public Action ItemRunOut;

    public ItemData(SellingItem sellingItem, int amount = 1)
    {
        SellingItem = sellingItem;
        Amount = amount;
    }

    public void Sell()
    {
        if (Amount == 0) return;

        Amount--;

        ItemSold?.Invoke(this);

        if (Amount == 0)
        {
            ItemRunOut?.Invoke();
        }
    }
}
