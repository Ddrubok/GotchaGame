using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Define;
using static Extension;

public class UI_RandomGotcha : UI_Buttons
{
    [SerializeField]
    private int GotchaNumberOfTimes;

    private ulong Price;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

       
        return true;
    }

    public override bool StartInit()
    {
        if (!base.StartInit())
            return false;

        Price = (ulong)(RequireGachaPrice * GotchaNumberOfTimes);
        return true;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if(Managers.Game.CanBuy(Price))
        {
            Managers.Sound.Play(ESound.Effect, "sfx_7");
            UI_GotchaPopup popup = Managers.UI.ShowPopupUI<UI_GotchaPopup>("Prefabs\\GotchaPopUP");
            popup.GotchaStart(GotchaNumberOfTimes);
        }
    }
}
