using UnityEngine;

public class CostumeChanger : MonoBehaviour
{
    [SerializeField] private Animator _characterAnimator;
    [SerializeField] private EquipmentInventory _equipmentInventory;

    private void Start()
    {
        _equipmentInventory.OnNewItemEquip += ApplyCostume;

        var costumeSlot = _equipmentInventory.InventorySlots.Find(x => x.EquipmentType == EquipmentType.Costume);

        ApplyCostume(costumeSlot.ItemData.SellingItem);
    }

    private void ApplyCostume(SellingItem costume)
    {
        _characterAnimator.runtimeAnimatorController = costume.Controller;
    }
}
