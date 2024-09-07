using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Define;

public class UI_PlayerInfo : UI_Base
{
    enum PlayerInfoText
    {
        Attack,
        Shield,
        HP,
    }
    private TextMeshProUGUI _attack;
    private TextMeshProUGUI _shield;
    private TextMeshProUGUI _HP;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;
        BindTextMeshs(typeof(PlayerInfoText));


        _attack = GetTextMesh((int)PlayerInfoText.Attack);
        _shield = GetTextMesh((int)PlayerInfoText.Shield);
        _HP = GetTextMesh((int)PlayerInfoText.HP);


        Managers.Game.OnCharacterAttackChanged -= HandleOnCharacterAttackChanged;
        Managers.Game.OnCharacterAttackChanged += HandleOnCharacterAttackChanged;

        Managers.Game.OnCharacterShiledChanged -= HandleOnCharacterShiledChanged;
        Managers.Game.OnCharacterShiledChanged += HandleOnCharacterShiledChanged;

        Managers.Game.OnCharacterHPChanged -= HandleOnCharacterHPChanged;
        Managers.Game.OnCharacterHPChanged += HandleOnCharacterHPChanged;
        return true;
    }

    private void HandleOnCharacterAttackChanged(ulong gt)
    {
        _attack.text = Util.ConvertToCurrencyFormat(gt);
    }

    private void HandleOnCharacterHPChanged(ulong gt)
    {
        _shield.text = Util.ConvertToCurrencyFormat(gt);
    }

    private void HandleOnCharacterShiledChanged(ulong gt)
    {
        _HP.text = Util.ConvertToCurrencyFormat(gt);
    }

    //private void OnDestroy()
    //{
    //    Managers.Game.OnCharacterAttackChanged -= HandleOnCharacterAttackChanged;
    //    Managers.Game.OnCharacterShiledChanged -= HandleOnCharacterShiledChanged;
    //    Managers.Game.OnCharacterHPChanged -= HandleOnCharacterHPChanged;
    //}


}