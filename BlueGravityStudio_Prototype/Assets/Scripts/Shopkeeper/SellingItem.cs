using UnityEngine;

[CreateAssetMenu(fileName = "Item_", menuName = "CustomSO")]
public class SellingItem : ScriptableObject
{
    public string DisplayName;
    public Sprite DisplayIcon;
    public int Price;
}
