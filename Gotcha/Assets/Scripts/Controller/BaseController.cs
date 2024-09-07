using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class BaseController : MonoBehaviour
{
    void Awake()
    {
        Init();
    }

    bool _init = false;
    public virtual bool Init()
    {
        if (_init)
            return false;

        _init = true;
        return true;
    }

    void Update()
    {
        UpdateController();
        AnimationEnd();
    }

    public virtual void UpdateController()
    {
    }

    protected virtual void AnimationEnd()
    {

    }
}
