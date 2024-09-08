using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Define;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ResourcesTap : UI_Base
{
    enum Text
    {
        BattlePower,
        SaveGold,
    }
    enum Images
    {
        GetGold,
        GoldImage

    }

    private TextMeshProUGUI _battlePower;
    private TextMeshProUGUI _saveGold;

    private Image _getGoldImage;
    private Image _goldImage;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;
        BindTextMeshs(typeof(Text));
        BindImages(typeof(Images));


        _battlePower = GetTextMesh((int)Text.BattlePower);
        _saveGold = GetTextMesh((int)Text.SaveGold);
        _getGoldImage = GetImage((int)Images.GetGold);
        _goldImage = GetImage((int)Images.GoldImage);



        Managers.Game.OnCharacterBattlePowerChanged -= HandleOnCharacterBattlePowerChanged;
        Managers.Game.OnCharacterBattlePowerChanged += HandleOnCharacterBattlePowerChanged;

        Managers.Game.OnSaveGoldChanged -= HandleOnSaveGoldChanged;
        Managers.Game.OnSaveGoldChanged += HandleOnSaveGoldChanged;

        _getGoldImage.gameObject.BindEvent(OnPointerDown, type: Define.EUIEvent.Click);
        return true;
    }

    private void HandleOnCharacterBattlePowerChanged(ulong gt)
    {
        _battlePower.text = Util.ConvertToCurrencyFormat(gt);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Managers.Sound.Play(ESound.Effect, "sfx_6");
        ulong check = (ulong)Managers.Game.SaveGold;
        Managers.Game.SaveGold -= check;
        Managers.Game.Gold += check;

    }

    void GetGoldOn()
    {
        _getGoldImage.raycastTarget = true;
        _goldImage.color = Color.white;
    }

    void GetGoldOff()
    {
        _getGoldImage.raycastTarget = false;
        _goldImage.color = Util.ColorToHexCode("#3C3C3C");
    }


    private void HandleOnSaveGoldChanged(double db)
    {
        _saveGold.text = Util.ConvertToCurrencyFormat((int)db);
        if (db >= Define.MinimumAmount)
        {
            GetGoldOn();
        }
        else
        {
            GetGoldOff();
        }
    }
}
