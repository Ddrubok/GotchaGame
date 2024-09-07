using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldSliderController : SliderController
{
    private float _timer;

    private float _timerInteval = 0.01f;
    private float Timer
    {
        get { return _timer; }
        set
        {
            
            _timer = value;
            slider.value = 1.0f-_timer/ Define.RefillMoneyInterval;
            RemainingTimeText.text = _timer.ToString("F1") + 's';
        }
    }

    [SerializeField]
    private TextMeshProUGUI RemainingTimeText;

    public override bool Init()
    {
        if (!base.Init())
            return false;
        return true;
    }

    private void Start()
    {
        TimerInit();
        InvokeRepeating("UpdateTimer", 0.0f, _timerInteval);
    }

    void TimerInit()
    {
        Timer = Define.RefillMoneyInterval;
    }

    void FinishTimer()
    {
        TimerInit();
        Debug.Log("¿Ï·á");
        Managers.Game.SaveGold += Define.RefillMoneyCount;
        //TODO
    }
    private void UpdateTimer()
    {
        if (_timer > 0)
        {
            Timer -= _timerInteval; 
        }
        else
        {
            FinishTimer();
           
        }
    }

    //public override void UpdateController()
    //{
    //    base.UpdateController();

    //    if (_timer > 0)
    //    {
    //        Timer -= Time.deltaTime;
    //    }
    //    else
    //    {
    //        FinishTimer();
    //    }
    //}
}
