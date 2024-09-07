using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static Define;

public class UI_ArmorTapButton : UI_EquipmentButtons
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        ItemType = ItemType.Armor;
        return true;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
    }
}
