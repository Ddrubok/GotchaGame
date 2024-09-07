using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class UI_EnhanceTap : UI_Base
{

    enum GameObjects
    {
        GetGoldValue,
    }

    GameObject _getGoldValue;
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObjects(typeof(GameObjects));

        _getGoldValue = GetObject((int)GameObjects.GetGoldValue);

        

        return true;
    }
}