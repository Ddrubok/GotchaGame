
using Data;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;

public class UI_ItemPopup : UI_Popup
{
    enum ObjectGame
    {
        Exit,
        StatusOfEquipmen,
    }

    enum Texts
    {
        LevelText,
        VolumeAndNextLevelVolume,
        Power
    }
    enum Images
    {
        ItemImage,
        Level,
        TypeImage
    }
    GameObject _Exit;
    Slider _StatusOfEquipment;

    TextMeshProUGUI _LevelText;
    TextMeshProUGUI _VolumeAndNextLevelVolume;
    TextMeshProUGUI _PowerText; 

    Image _ItemImage;
    Image _Level;
    Image _TypeImage;


   

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObjects(typeof(ObjectGame));
        BindImages(typeof(Images));
        BindTextMeshs(typeof(Texts));


        _Exit = GetObject((int)ObjectGame.Exit);
        _StatusOfEquipment = GetObject((int)ObjectGame.StatusOfEquipmen).GetComponent<Slider>();

        _LevelText = GetTextMesh((int)Texts.LevelText);
        _VolumeAndNextLevelVolume = GetTextMesh((int)Texts.VolumeAndNextLevelVolume); 
        _PowerText = GetTextMesh((int)Texts.Power);

        _ItemImage = GetImage((int)Images.ItemImage);
        _Level = GetImage((int)Images.Level);
        _TypeImage = GetImage((int)Images.TypeImage);

        _Exit.BindEvent(Close, type: Define.EUIEvent.PointerDown);
        return true;
    }

    public void SetPopUp(Sprite itemImage,Color _Levelcolor, Sprite rate, string level, string vAn, int power, float value)
    {
        _ItemImage.sprite = itemImage;
        _Level.color = _Levelcolor;
        _TypeImage.sprite = rate;
        _LevelText.text = level;
        _VolumeAndNextLevelVolume.text = vAn;
        _PowerText.text =Util.ConvertToCurrencyFormat(power);
        _StatusOfEquipment.value = value;
    }

    public void Close(PointerEventData evt)
    {
        Managers.UI.ClosePopupUI(this);
    }
    
   


    public override bool StartInit()
    {
        if (!base.StartInit())
            return false;

        return true;
    }
   
}

