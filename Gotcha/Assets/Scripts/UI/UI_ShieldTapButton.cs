using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Define;
public class UI_ShieldTapButton : UI_EquipmentButtons
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        ItemType = ItemType.Shield;
        return true;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
    }
}
