using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    private GameObject Target;
    void Start()
    {
        Managers.Game.Camera = this;
    }

    public void TargetChange(GameObject _Target)
    {
        Target = _Target;

    }
}
