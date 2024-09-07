using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using static Define;

public class UI_ResourcesTapButton : UI_TapButton
{

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        GameTap = GameTap.Resources;
        return true;
    }
}

