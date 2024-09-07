using Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using static Define;
using static Util;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public interface ILoader<Value>
{
    void GetData();
}

public class DataManager
{

    public Dictionary<int, Data.TestData> TestDic { get; private set; } = new Dictionary<int, Data.TestData>();
    public Dictionary<int, GachaRandomBagData> GachaRandomBagDataDic { get; private set; } = new Dictionary<int, Data.GachaRandomBagData>();
    public Dictionary<int, GachaGradeInfoData> GachaGradeInfoDataDic { get; private set; } = new Dictionary<int, Data.GachaGradeInfoData>();
    public Dictionary<int, ItemListData> ItemListDataDic { get; private set; } = new Dictionary<int, Data.ItemListData>();
    public SortedDictionary<int, ItemOptionUpgradeData> ItemOptionUpgradeDataDic { get; private set; } = new SortedDictionary<int, Data.ItemOptionUpgradeData>();

    public int GotchaSize { get; private set; } 

    

    public void Init()
    {
        GachaRandomBagDataDic = CreateDictionaryFromList(ReadCsv<GachaRandomBagData>("GachaRandomBag"), ga => ga.GachaRewardID);
        GachaGradeInfoDataDic = CreateDictionaryFromList(ReadCsv<GachaGradeInfoData>("GachaGradeInfo"), ga => ga.GachaID);
        ItemListDataDic = CreateDictionaryFromList(ReadCsv<ItemListData>("ItemList"), ga => ga.ItemID);
        ItemOptionUpgradeDataDic = CreateSortedDictionaryDictionaryFromList(ReadCsv<ItemOptionUpgradeData>("ItemOptionUpgrade"), ga => ga.UpgradeBelowLimit);
        GotchaSize = GachaGradeInfoDataDic.Count;

        foreach (var items in GachaGradeInfoDataDic)
        {
            items.Value.SetData();
        }
        GlobalValueData gvd =  ReadCsv<GlobalValueData>("GlobalValue")[0];

        {
            RefillMoneyInterval = gvd._RefillMoneyInterval;
            RefillMoneyCount = gvd._RefillMoneyCount;
            DefaultMoneyCount = gvd._DefaultMoneyCount;
            RequireGachaPrice = gvd._RequireGachaPrice;
            MaxMoneyLimit = gvd._MaxMoneyLimit;
            MinimumAmount = gvd._MinimumAmount;
            LevelUpTextTime = gvd._LevelUpTextTime; 
        }

        Debug.Log("���� ������ �ε� �Ϸ�");
    }

    private Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>("Data\\" + path);
        return JsonConvert.DeserializeObject<Loader>(textAsset.text);
    }

    private Loader LoadJson<Loader, Value>(string path) where Loader : ILoader<Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>("Data\\" + path);
        return JsonConvert.DeserializeObject<Loader>(textAsset.text);
    }

    public static List<T> ReadCsv<T>(string path) where T : new()
    {
        List<T> dataList = new List<T>();

        TextAsset textAsset = Managers.Resource.Load<TextAsset>("Data\\" + path);
        if (textAsset == null)
        {
            Debug.LogError($"CSV ������ ã�� �� �����ϴ�: {path}");
            return null;
        }

        using (StringReader reader = new StringReader(textAsset.text))
        {
            string line;
            bool isHeader = true;

            while ((line = reader.ReadLine()) != null)
            {
                if (isHeader)
                {
                    isHeader = false;
                    continue;
                }
                T data = ParseCsvLine<T>(line);
                dataList.Add(data);
            }
        }

        return dataList;
    }

    private static T ParseCsvLine<T>(string line) where T : new()
    {
        T data = new T();
        string[] values = line.Split(',');

        var properties = typeof(T).GetProperties();
        for (int i = 0; i < properties.Length && i < values.Length; i++)
        {
            var property = properties[i];
            if (property.CanWrite)
            {
                object value;

                if (property.PropertyType.IsEnum)
                {
                    value = Enum.Parse(property.PropertyType, values[i]);
                }
                else
                {
                    value = Convert.ChangeType(values[i], property.PropertyType);
                }

                property.SetValue(data, value);
            }
        }

        return data;
    }
}
