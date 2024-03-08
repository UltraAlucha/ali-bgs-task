using System;

[Serializable]
public struct ItemData
{
    public SellingItem SellingItem;
    public int Amount;

    public Action<ItemData> ItemSold;
    public Action ItemRunOut;

    public void Sell()
    {
        if (Amount == 0) return;

        Amount--;

        ItemSold?.Invoke(this);

        if (Amount == 0)
        {
            ItemRunOut.Invoke();
        }
    }
}
