using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using static Define;

public class UI_GotchaTap : UI_Base
{

    enum GameObjects
    {
        Attack,
        Shield,
        HP,
    }
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObjects(typeof(GameObjects));

        for (int i = 0; i <= (int)GameObjects.HP; i++)
        {
            Managers.Game.Equipment[i] = GetObject(i).transform;
        }
       


        Managers.Game.OnEquipmentTapChanged -= HandleOnEquipmentTapChanged;
        Managers.Game.OnEquipmentTapChanged += HandleOnEquipmentTapChanged;
        return true;
    }
    private void HandleOnEquipmentTapChanged(ItemType it)
    {
        ChangeTap((int)it);
    }

    void ChangeTap(int n)
    {
        CloseAllTap();

        GetObject(n).SetActive(true);
      
        
    }

    void CloseAllTap()
    {
        for (int i = 0; i <= (int)GameObjects.HP; i++)
        {
            GetObject(i).SetActive(false);
        }
    }
}
