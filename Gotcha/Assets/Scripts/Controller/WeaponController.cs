using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : ItemController
{
    public override void MoveSetting()
    {
        Managers.Game.AbsoluteAttackValue += (ulong)DefaultPower;
    }
    public override void PowerApplication()
    {
        Managers.Game.AbsoluteAttackValue += (ulong)UpgradePower;
    }

    //public override void AfterInit(Define.Rating rate, Define.ItemType it, int id)
    //{
    //    base.AfterInit(rate, it, id);

    //    Managers.Game.AbsoluteAttackValue += (ulong)Power;
    //}
}
