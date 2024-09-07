using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Define
{
    public enum Item
    {
        Boarder,
        ItemImage,
        Level,
        LevelUp,
        StatusOfEquipmen,
        AbsoluteNumber,
    }

    public enum EScene
    {
        TitleScene,
        GameScene,
        Unknown,
    }

    public enum GameTap
    {
        Resources,
        Gotcha,
        Enhance,
    }

    public enum EUIEvent
    {
        Click,
        PointerDown,
        PointerUp,
        Drag,
    }

    public enum ESound
    {
        Bgm,
        Effect,
        Max,
    }

    public enum Rating
    {
        Normal,
        Rare,
        Epic,
        Size,
    }

    public enum ItemType
    {
        Weapon,
        Armor,
        Shield,
        None,
        
    }

    public enum ItemOption
    {
        DefenseIncrease,
        HpIncrease,
        AttackIncrease,
    }






    public static float RefillMoneyInterval;
    public static float RefillMoneyCount;
    public static int DefaultMoneyCount;
    public static int RequireGachaPrice;
    public static int MaxMoneyLimit;
    public static int MinimumAmount;
    public static float LevelUpTextTime ;




}
