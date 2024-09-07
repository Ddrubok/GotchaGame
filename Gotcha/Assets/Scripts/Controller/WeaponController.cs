using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : ItemController
{
    public override void PowerApplication()
    {
        Managers.Game.CharacterAttack += (ulong)UpgradePower;
    }
}
