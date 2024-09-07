using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_EnhanceAttackButton : UI_EnhanceButtons
{
   float _value;

    public float Value
    {
        get { return _value; }

        set
        {
            _value = value;
            CurrentValueText.text = _value.ToString("F2");
            ChangeValueText.text = (IncreaseValue + _value).ToString("F2");


            Managers.Game.AttMagnification = _value;
        }
    }

    float _increaseValue;

    public float IncreaseValue
    {
        get { return _increaseValue; }

        set
        {
            _increaseValue = value;
        }
    }

    public override void ApplicationButton()
    {
        Value += IncreaseValue;
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        TitleText.text = "공격력 배수";
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

}
