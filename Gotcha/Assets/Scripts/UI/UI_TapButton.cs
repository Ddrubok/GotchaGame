using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Define;

public class UI_TapButton : UI_Buttons
{
    public GameTap GameTap { get; set; }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Managers.Game.OnGameTapChanged -= HandleOnGameTapChanged;
        Managers.Game.OnGameTapChanged += HandleOnGameTapChanged;
        return true;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(GameTap + " ¹öÆ°");
        Managers.Game.GameTap = GameTap;
    }

    public  void HandleOnGameTapChanged(GameTap gt)
    {
        if (gt == GameTap)
            TapOn();
        else
            TapOff();
    }
}
