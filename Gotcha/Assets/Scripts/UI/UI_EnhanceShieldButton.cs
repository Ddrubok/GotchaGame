using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_EnhanceShieldButton : UI_EnhanceButtons
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        TitleText.text = "방어력 배수";
        return true;
    }

    public override bool StartInit()
    {
        if (base.StartInit() == false)
            return false;
        IncreaseValue = 0.1f;
        Value = 1.0f;
        return true;
    }

    public override void ValueApllication(float v)
    {
        Managers.Game.HPMagnification = v;
    }
}
