using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.WSA;
using static Define;

public abstract class UI_Buttons : UI_Base
{
    enum GameObjects
    {
        ButtonImage,
    }

    private GameObject _resources;
    private Image _tapImage;

    private TextMeshProUGUI _text;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;
        BindObjects(typeof(GameObjects));

        _resources = GetObject((int)GameObjects.ButtonImage);

        _tapImage = _resources.GetComponent<Image>();

        _text = _resources.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        _resources.BindEvent(OnPointerDown, type: Define.EUIEvent.Click);


        return true;
    }


    public void TextColorChange(Color color)
    {
        _text.color = color;
    }

    public void TapImageColorChange(Color color)
    {
        _tapImage.color = color;
    }

    public virtual void TapOn()
    {
        TextColorChange(Color.white);
        TapImageColorChange(Util.ColorToHexCode("#166083"));
    }

    public virtual void TapOff()
    {
        TextColorChange(Color.black);
        TapImageColorChange(Color.white);
    }

    public abstract void OnPointerDown(PointerEventData eventData);

}
