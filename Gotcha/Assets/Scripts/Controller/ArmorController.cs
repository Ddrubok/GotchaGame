using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorController : ItemController
{
    public override void MoveSetting()
    {
        Managers.Game.AbsoluteHPValue += (ulong)DefaultPower;
    }

    public override void PowerApplication()
    {
        Managers.Game.AbsoluteHPValue += (ulong)UpgradePower;
    }

    //public override void AfterInit(Define.Rating rate, Define.ItemType it, int id)
    //{
    //    base.AfterInit(rate, it, id);

    //    Managers.Game.AbsoluteHPValue += (ulong)Power;
    //}
}
