using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UI_EnhanceButtons : UI_Buttons
{
    float _value;

    public float Value
    {
        get { return _value; }

        set
        {
            _value = value;
            CurrentValueText.text = _value.ToString("F2");
            ChangeValueText.text = (IncreaseValue + _value).ToString("F2");
            ValueApllication(Value);
        }
    }

    public abstract void ValueApllication(float v);
    

    float _increaseValue;

    public float IncreaseValue
    {
        get { return _increaseValue; }

        set
        {
            _increaseValue = value;
        }
    }

    int _MoneyValue;
    int Money
    {
        get { return _MoneyValue; }

        set
        {
            _MoneyValue = value;
            MoneyText.text = _MoneyValue.ToString();
        }
    }

    int _increaseInMoney;

    int IncreaseInMoney
    {
        get { return _increaseInMoney; }

        set
        {
            _increaseInMoney = value;
        }
    }


    enum TextMesh
    {
        Title,
        CurrentValue,
        ChangeValue,
        MoneyValue,
    }

    public TextMeshProUGUI TitleText { get; private set; }
    public TextMeshProUGUI CurrentValueText { get; private set; }
    public TextMeshProUGUI ChangeValueText { get; private set; }
    public TextMeshProUGUI MoneyText { get; private set; }


    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindTextMeshs(typeof(TextMesh));

        TitleText = GetTextMesh((int)TextMesh.Title);
        CurrentValueText = GetTextMesh((int)TextMesh.CurrentValue);
        ChangeValueText = GetTextMesh((int)TextMesh.ChangeValue);
        MoneyText = GetTextMesh((int)TextMesh.MoneyValue);

        _MoneyValue = 100;
        IncreaseInMoney = 10;

        return true;
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        BuyMoneyAndIncrease();
    }

    public void BuyMoneyAndIncrease()
    {
        if (Managers.Game.CanBuy((ulong)Money))
        {
            Money += IncreaseInMoney;
            ApplicationButton();
        }
    }

    public virtual void ApplicationButton()
    {
        Value += IncreaseValue;
    }
}
