using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Define;

public class UI_EquipmentButtons : UI_Buttons
{
    protected ItemType ItemType { get; set; }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Managers.Game.OnEquipmentTapChanged -= HandleOnEquipmentTapChanged;
        Managers.Game.OnEquipmentTapChanged += HandleOnEquipmentTapChanged;

        return true;
    }

    public void HandleOnEquipmentTapChanged(ItemType itemType)
    {
        if (itemType == ItemType)
            TapOn();
        else
            TapOff();
    }
    public override void TapOn()
    {
        TapImageColorChange(Util.ColorToHexCode("#0C2F43"));
    }

    public override void TapOff()
    {
        TapImageColorChange(Util.ColorToHexCode("#125D89"));
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(ItemType + " ¹öÆ°");
        Managers.Game.EquipmentTap = ItemType;
    }
}
