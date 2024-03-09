using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_", menuName = "ItemSO")]
public class SellingItem : ScriptableObject
{
    public string DisplayName;
    public Sprite DisplayIcon;
    public int Price;
    public EquipmentType EquipmentType;
    public RuntimeAnimatorController Controller;
}

public enum EquipmentType
{
    Costume, Hat
}
