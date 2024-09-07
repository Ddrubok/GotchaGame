using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Define;

public class UI_WeaponTapButton : UI_EquipmentButtons
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        ItemType = ItemType.Weapon;
        return true;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
    }
}
