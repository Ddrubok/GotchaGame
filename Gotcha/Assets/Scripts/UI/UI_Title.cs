using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static Define;

public class UI_Title : UI_Base
{

    enum Text
    {
        TapName,
        Gold,
    }
    private TextMeshProUGUI _tapName;
    private TextMeshProUGUI _gold;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;
        BindTextMeshs(typeof(Text));

        _tapName = GetTextMesh((int)Text.TapName);
        _gold = GetTextMesh((int)Text.Gold);

        Managers.Game.OnGameTapChanged -= HandleOnGameTapChanged;
        Managers.Game.OnGameTapChanged += HandleOnGameTapChanged;

        Managers.Game.OnGoldChanged -= HandleOnGoldChanged;
        Managers.Game.OnGoldChanged += HandleOnGoldChanged;
        return true;
    }

    private void HandleOnGameTapChanged(GameTap gt)
    {
        if (gt == GameTap.Resources)
            _tapName.text = "ÀÚ¿ø";
        else
            _tapName.text = "»Ì±â";
    }

    private void HandleOnGoldChanged(ulong gt)
    {
        _gold.text = Util.ConvertToCurrencyFormat(gt);
    }
}
