using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : ItemController
{
    public override void PowerApplication()
    {
        Managers.Game.CharacterShiled += (ulong)UpgradePower;
    }
}
