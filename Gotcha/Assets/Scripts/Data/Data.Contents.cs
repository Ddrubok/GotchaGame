using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

namespace Data
{
    #region TestData
    [Serializable]
    public class TestData
    {
        public int Level;
        public int Exp;
        public List<int> Skills;
        public float Speed;
        public string Name;
    }

    [Serializable]
    public class TestDataLoader : ILoader<int, TestData>
    {
        public List<TestData> tests = new List<TestData>();

        public Dictionary<int, TestData> MakeDict()
        {
            Dictionary<int, TestData> dict = new Dictionary<int, TestData>();
            foreach (TestData testData in tests)
                dict.Add(testData.Level, testData);

            return dict;
        }
    }
    #endregion

    #region GachaRandomBagData
    [Serializable]
    public class GachaRandomBagData
    {
        public int DropID { get; set; }
        public Rating rate { get; set; }
        public ItemType type { get; set; }
        public int GachaRewardID { get; set; }

    }

    [Serializable]
    public class GachaRandomBagLoader : ILoader<int, GachaRandomBagData>
    {
        public List<GachaRandomBagData> GachaDatas = new List<GachaRandomBagData>();

        public Dictionary<int, GachaRandomBagData> MakeDict()
        {
            Dictionary<int, GachaRandomBagData> dict = new Dictionary<int, GachaRandomBagData>();
            foreach (GachaRandomBagData gachaData in GachaDatas)
                dict.Add(gachaData.DropID, gachaData);

            return dict;
        }
    }
    #endregion

    #region GachaGradeInfoData
    [Serializable]
    public class GachaGradeInfoData
    {
        public int GachaID { get; set; }
        public int NormalGachaRate { get; set; }
        public int RareGachaRate { get; set; }
        public int EpicGachaRate { get; set; }
        public int GachaRandombagID { get; set; }

        public void SetData()
        {
            EpicGachaRate += RareGachaRate += NormalGachaRate;
        }
    }

    [Serializable]
    public class GachaGradeInfoDataLoader : ILoader<int, GachaGradeInfoData>
    {
        public List<GachaGradeInfoData> GachaInfoDatas = new List<GachaGradeInfoData>();

        public Dictionary<int, GachaGradeInfoData> MakeDict()
        {
            Dictionary<int, GachaGradeInfoData> dict = new Dictionary<int, GachaGradeInfoData>();
            foreach (GachaGradeInfoData gachaInfoData in GachaInfoDatas)
                dict.Add(gachaInfoData.GachaID, gachaInfoData);

            return dict;
        }
    }
    #endregion

    #region ItemListData
    [Serializable]
    public class ItemListData
    {
        public int ItemID { get; set; }
        public Rating ItemGrade { get; set; }
        public ItemOption ItemOptionType { get; set; }
        public int DefaultValue { get; set; }
        public string IconPath { get; set; }
    }

    [Serializable]
    public class ItemListDataLoader : ILoader<int, ItemListData>
    {
        public List<ItemListData> tests = new List<ItemListData>();

        public Dictionary<int, ItemListData> MakeDict()
        {
            Dictionary<int, ItemListData> dict = new Dictionary<int, ItemListData>();
            foreach (ItemListData testData in tests)
                dict.Add(testData.ItemID, testData);

            return dict;
        }
    }
    #endregion

    #region ItemOptionUpgradeData
    [Serializable]
    public class ItemOptionUpgradeData
    {
        public int UpgradeBelowLimit { get; set; }
        public int UpgradeCost { get; set; }
        public int NormalUpgradeValue { get; set; }
        public int RareUpgradeValue { get; set; }
        public int EpicUpgradeValue { get; set; }
    }

    [Serializable]
    public class ItemOptionUpgradeDataLoader : ILoader<int, ItemOptionUpgradeData>
    {
        public List<ItemOptionUpgradeData> ItemOptionUpgradeDatas = new List<ItemOptionUpgradeData>();

        public Dictionary<int, ItemOptionUpgradeData> MakeDict()
        {
            Dictionary<int, ItemOptionUpgradeData> dict = new Dictionary<int, ItemOptionUpgradeData>();
            foreach (ItemOptionUpgradeData itemOptionUpgradeData in ItemOptionUpgradeDatas)
                dict.Add(itemOptionUpgradeData.UpgradeBelowLimit, itemOptionUpgradeData);

            return dict;
        }
    }
    #endregion

    #region GlobalValueData

    public class GlobalValueData
    {
        public float _RefillMoneyInterval { get; set; }
        public float _RefillMoneyCount { get; set; }
        public int _DefaultMoneyCount { get; set; }
        public int _RequireGachaPrice { get; set; }
        public int _MaxMoneyLimit { get; set; }

        public int _MinimumAmount { get; set; }

        public float _LevelUpTextTime { get; set; }

    }

    [Serializable]
    public class GlobalValueLoader : ILoader<GlobalValueData>
    {
        public GlobalValueData GlobalValueData = new GlobalValueData();

        public void GetData()
        {
            RefillMoneyInterval = GlobalValueData._RefillMoneyInterval;
            RefillMoneyCount = GlobalValueData._RefillMoneyCount;
            DefaultMoneyCount = GlobalValueData._DefaultMoneyCount;
            RequireGachaPrice = GlobalValueData._RequireGachaPrice;
            MaxMoneyLimit = GlobalValueData._MaxMoneyLimit;
        }
    }
    #endregion

}