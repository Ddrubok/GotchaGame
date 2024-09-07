using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorController : ItemController
{

    public override void PowerApplication()
    {
        Managers.Game.CharacterHP += (ulong)UpgradePower;
    }
}
