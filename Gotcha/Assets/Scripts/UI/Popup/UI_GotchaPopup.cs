using Data;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static Define;

public class UI_GotchaPopup : UI_Popup
{

    Dictionary<int, ItemController> itemObject = new Dictionary<int, ItemController>();
    enum ObjectGame
    {
        Contents,
        Exit,
    }

    GameObject _Contents;
    GameObject _Exit;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObjects(typeof(ObjectGame));

        _Contents = GetObject((int)ObjectGame.Contents);
        _Exit = GetObject((int)ObjectGame.Exit);
        //Refresh();

        _Exit.BindEvent(Close, type: Define.EUIEvent.PointerDown);
        return true;
    }

    public void Close(PointerEventData evt)
    {
        ApplicationEquipment();
        Managers.UI.ClosePopupUI(this);
    }
    public override bool StartInit()
    {
        if (!base.StartInit())
            return false;

        return true;
    }

    public void GotchaStart(int num)
    {
        for (int i = 0; i < num; i++)
        {
            //GotchaTest();
            Gotcha();
        }
    }

    public void ApplicationEquipment()
    {
        foreach (var a in itemObject)
        {
            if (Managers.Object.Item.ContainsKey(a.Value.Type))
            {
                if (Managers.Object.Item[a.Value.Type].ContainsKey(a.Key))
                {
                    Managers.Object.Item[a.Value.Type][a.Key].AbsoluteVolume += a.Value.AbsoluteVolume;
                    Managers.Object.Item[a.Value.Type][a.Key].VolumeApplication(a.Value.AbsoluteVolume);
                }
                else
                {
                    Managers.Object.Item[a.Value.Type].Add(a.Key, a.Value);
                    MoveObject(a.Value, Managers.Game.Equipment[(int)a.Value.Type]);
                }
            }
            else
            {
                Dictionary<int, ItemController> newItemDict = new Dictionary<int, ItemController>();
                newItemDict.Add(a.Key, a.Value); 
                Managers.Object.Item.Add(a.Value.Type, newItemDict);

                MoveObject(a.Value, Managers.Game.Equipment[(int)a.Value.Type]);
            }


        }
    }

    public void MoveObject(ItemController IC,Transform parent)
    {
        IC.transform.SetParent(parent);
        IC.transform.position = Vector3.zero;
        IC.transform.localScale = Vector3.one;
        IC.EquipmentTap();
    }

    public Rating GetRating(GachaGradeInfoData data)
    {
        int num = UnityEngine.Random.Range(0, 100);

        if (num < data.NormalGachaRate)
            return Rating.Normal;
        else if (num < data.RareGachaRate)
            return Rating.Rare;
        else
            return Rating.Epic;
    }

    public int RatingNumber(Rating rt)
    {
        int num = 0;

        if (rt == Rating.Epic)
        {
            num = Random.Range(9, 11);
        }
        else if (rt == Rating.Rare)
        {
            num = Random.Range(6, 9);
        }
        else
            num = Random.Range(1, 6);

        return num;
    }
    public void Gotcha()
    {
        int num = Random.Range((int)ItemType.Weapon, (int)ItemType.None )+1;
        Rating rate = GetRating(Managers.Data.GachaGradeInfoDataDic[num]);
        int itemNum = num * 100 + RatingNumber(rate);

        if (itemObject.ContainsKey(itemNum))
        {
            itemObject[itemNum].AbsoluteVolume++;
        }
        else
        {
            ItemController ic = Spawn(num - 1);
            ic.AfterInit(rate, (ItemType)num - 1, itemNum);
            itemObject.Add(itemNum, ic);
        }
    }

    public void GotchaTest()
    {
        int num =1;
        Rating rate = GetRating(Managers.Data.GachaGradeInfoDataDic[num]);
        int itemNum = num * 100 + RatingNumber(rate);

        if (itemObject.ContainsKey(itemNum))
        {
            itemObject[itemNum].AbsoluteVolume++;
        }
        else
        {
            ItemController ic = Spawn(num - 1);
            ic.AfterInit(rate, (ItemType)num - 1, itemNum);
            itemObject.Add(itemNum, ic);
        }
    }
    public ItemController Spawn(int itemType)
    {
        return Managers.Object.Spawn<ItemController>(Vector3.zero, itemType, _Contents.transform);
    }
}
