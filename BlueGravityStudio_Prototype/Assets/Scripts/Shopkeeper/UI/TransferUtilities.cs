public static class TransferUtilities
{
    public static void CommitTransfer(Inventory from, Inventory to, SellingItem item)
    {
        from.TransferItem(to, item);
    }
}
