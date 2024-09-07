using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;
using static Util;


public abstract class ItemController : BaseController
{
    [field: SerializeField]
    public Image ItemImage { get; private set; }

    [field: SerializeField]
    public GameObject LevelUpText { get; private set; }

    [field: SerializeField]
    public Image RatingImage { get; private set; }

    [field: SerializeField]
    public TextMeshProUGUI LevelText { get; private set; }

    [field: SerializeField]
    public TextMeshProUGUI Volume_NextLevelVolume { get; private set; }

    [field: SerializeField]
    public Slider Slider { get; private set; }

    [field: SerializeField]
    public TextMeshProUGUI AbsoluteNumber { get; private set; }


    private int _upgradePower;

    public int UpgradePower
    {
        get { return _upgradePower; }

        set
        {
            _upgradePower = value;
        }
    }
    protected int DefaultPower;

    [SerializeField]
    private int _power;
    public int Power
    {
        get
        {
            return _power;
        }
        set
        {
            _power = value;
            PowerApplication();
        }
    }

    private int _level = 1;
    public int Level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
            ChangeLevelText();
        }
    }

    private int _nextLevelVolume;

    public int NextLevelVolume
    {
        get
        {
            return _nextLevelVolume;
        }
        set
        {
            _nextLevelVolume = value;
        }
    }

    private int _absoluteVolume;

    public int AbsoluteVolume
    {
        get { return _absoluteVolume; }
        set
        {

            _absoluteVolume = value;
            AbsoluteNumber.text = _absoluteVolume.ToString();
        }
    }

    private int _volume;

    public int Volume
    {
        get
        {
            return _volume;
        }
        set
        {
            _volume = value;


            while (_volume >= NextLevelVolume)
            {
                _volume -= NextLevelVolume;
                LevelUp();
            }

            Slider.value = (float)_volume / _nextLevelVolume;
            SetVolumeAndNextLevel();
        }
    }

    public Rating Rate { get; private set; } = Rating.Rare;

    public ItemType Type { get; private set; }

    private int _id;
    public int Id
    {
        get { return _id; }
        private set
        {
            _id = value;
            ItemImage.sprite = Managers.Object.GetSprite(Managers.Data.ItemListDataDic[_id].IconPath);
        }
    }

    public void ChangeLevelText()
    {
        LevelText.text = $"Lv.{Level.ToString()}";
    }

    private Coroutine LevelUpCoroutine;
    public void LevelUp()
    {
        Level += 1;
        UpgradeSetting();
        if (Managers.Game.EquipmentTap == Type && LevelUpCoroutine == null && Level > 1)
            LevelUpCoroutine = StartCoroutine(LevelUpTextOnOff());

    }



    IEnumerator LevelUpTextOnOff()
    {
        LevelUpText.SetActive(true);
        yield return new WaitForSeconds(LevelUpTextTime);
        LevelUpText.SetActive(false);
        LevelUpCoroutine = null;
    }

    private void OnDisable()
    {
        LevelUpText.SetActive(false);
        LevelUpCoroutine = null;
    }

    void SetVolumeAndNextLevel()
    {
        Volume_NextLevelVolume.text = $"{Volume} / {NextLevelVolume}";
    }

    public abstract void PowerApplication();


    public override bool Init()
    {
        if (!base.Init())
            return false;

        ItemImage = transform.GetChild((int)Item.ItemImage).GetComponent<Image>();

        LevelUpText = transform.GetChild((int)Item.LevelUp).gameObject;
        LevelUpText.SetActive(false);

        RatingImage = transform.GetChild((int)Item.Level).GetComponent<Image>();

        LevelText = transform.GetChild((int)Item.Level).GetChild(0).GetComponent<TextMeshProUGUI>();

        Volume_NextLevelVolume = transform.GetChild((int)Item.StatusOfEquipmen).GetChild(2).GetComponent<TextMeshProUGUI>();

        Slider = transform.GetChild((int)Item.StatusOfEquipmen).GetComponent<Slider>();

        AbsoluteNumber = transform.GetChild((int)Item.AbsoluteNumber).GetChild(0).GetComponent<TextMeshProUGUI>();


        return true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UI_ItemPopup popup = Managers.UI.ShowPopupUI<UI_ItemPopup>("Prefabs\\ItemPopUP");
        Sprite get = GetTypeImage();
        popup.SetPopUp(ItemImage.sprite, RatingImage.color, get, LevelText.text, Volume_NextLevelVolume.text, Power, Slider.value);
        Debug.Log(Type + " 오픈 아이템 PopUp창");
    }

    Sprite GetTypeImage()
    {
        string a = "Ui\\";

        if (Type == ItemType.Weapon)
        {
            a += "Attack";
        }
        else if (Type == ItemType.Armor)
        {
            a += "Defense";
        }
        else if (Type == ItemType.Shield)
        {
            a += "Health";
        }
        Sprite get = Managers.Object.GetSprite(a);
        return get;
    }
    public virtual void AfterInit(Rating rate, ItemType it, int id)
    {
        Id = id;
        Type = it;
        Rate = rate;
        AbsoluteVolume++;

        DefaultPower = Managers.Data.ItemListDataDic[id].DefaultValue;
        Power = DefaultPower;

        RatingImage.color = GetColor(Rate);
        InitUpgradeSetting();
    }

    public void UpgradeSetting()
    {
        int CheckLevel = GetTransformedValue(Level, Managers.Data.ItemOptionUpgradeDataDic);
        NextLevelVolume = Managers.Data.ItemOptionUpgradeDataDic[CheckLevel].UpgradeCost;
        UpgradePower = GetUpgradePower(Managers.Data.ItemOptionUpgradeDataDic[CheckLevel]);

        Power += UpgradePower;

        //SetVolumeAndNextLevel();
    }

    public void InitUpgradeSetting()
    {
        int CheckLevel = GetTransformedValue(Level, Managers.Data.ItemOptionUpgradeDataDic);
        NextLevelVolume = Managers.Data.ItemOptionUpgradeDataDic[CheckLevel].UpgradeCost;
        UpgradePower = GetUpgradePower(Managers.Data.ItemOptionUpgradeDataDic[CheckLevel]);
        SetVolumeAndNextLevel();
    }


    public int GetUpgradePower(ItemOptionUpgradeData id)
    {
        int getUpgradePower = 0;
        if (Rate == Rating.Normal)
            getUpgradePower = id.NormalUpgradeValue;
        else if (Rate == Rating.Rare)
            getUpgradePower = id.RareUpgradeValue;
        else if (Rate == Rating.Epic)
            getUpgradePower = id.EpicUpgradeValue;

        return getUpgradePower;
    }

    public void SetGotchaTap()
    {
        Slider.gameObject.SetActive(false);
        AbsoluteNumber.transform.parent.gameObject.SetActive(true);
    }

    public void EquipmentTap()
    {
        Slider.gameObject.SetActive(true);
        AbsoluteNumber.transform.parent.gameObject.SetActive(false);
        VolumeApplication(AbsoluteVolume);
        gameObject.BindEvent(OnPointerDown, type: Define.EUIEvent.Click);
        MoveSetting();
    }

    public abstract void MoveSetting();

    public void VolumeApplication(int num)
    {
        Volume += num;
    }


}
