using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Define;

public class UI_GotchaButton : UI_TapButton
{

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        GameTap = GameTap.Gotcha;
        return true;
    }
}
