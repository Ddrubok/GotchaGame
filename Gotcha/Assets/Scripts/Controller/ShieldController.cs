using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : ItemController
{
    public override void MoveSetting()
    {
        Managers.Game.AbsoluteShiledValue += (ulong)DefaultPower;
    }
    public override void PowerApplication()
    {
        Managers.Game.AbsoluteShiledValue += (ulong)UpgradePower;
    }

    //public override void AfterInit(Define.Rating rate, Define.ItemType it, int id)
    //{
    //    base.AfterInit(rate, it, id);

    //    Managers.Game.AbsoluteShiledValue += (ulong)Power;
    //}
}
