using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class UI_EnhanceTapButton : UI_TapButton
{

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        GameTap = GameTap.Enhance;
        return true;
    }
}