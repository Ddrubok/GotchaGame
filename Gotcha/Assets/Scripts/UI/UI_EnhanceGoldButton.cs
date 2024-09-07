using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public  class UI_EnhanceGoldButton : UI_EnhanceButtons
{

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        TitleText.text = "°ρµε Αυ°΅·®";
        return true;
    }

    public override bool StartInit()
    {
        if (base.StartInit() == false)
            return false;
        IncreaseValue = Define.RefillMoneyCount / 10.0f;
        Value = Define.RefillMoneyCount;
        return true;
    }

    public override void ValueApllication(float v)
    {
        Define.RefillMoneyCount = v;
    }
}