using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class GameScene : BaseScene
{
    [SerializeField]
    private GameObject canvas;
    public override bool Init()
    {
        if (base.Init() == false)
            return false;
        Managers.Data.Init();

        canvas.SetActive(true);
        return true;
    }

    private void Start()
    {
        SceneDataInit();
    }

    private void SceneDataInit()
    {
        Managers.Game.GameTap = GameTap.Resources;
        Managers.Game.EquipmentTap = ItemType.Weapon;
        Managers.Game.Gold = (ulong)DefaultMoneyCount;

        Managers.Game.CharacterAttack = 0;
        Managers.Game.CharacterShiled = 0;
        Managers.Game.CharacterHP = 0;
        Managers.Game.SaveGold = 0;

    }
    public override void Clear()
    {

    }
}
