using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : BaseController
{
    public Slider slider { get; private set; }

    public override bool Init()
    {
        if (!base.Init())
            return false;

        slider = GetComponent<Slider>();
        return true;
    }
}
