using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbillityShoot : PlayerAbillityBase
{
    public GunBase gunBase;

    protected override void Init()
    {
        base.Init();

        inputs.Gameplay.Shoot.performed += cts => StartShoot();
        inputs.Gameplay.Shoot.canceled += cts => CancelShoot();
    }

    private void StartShoot()
    {
        gunBase.StartShoot();
        Debug.Log("Shoot");
    }

    private void CancelShoot()
    {
        Debug.Log("Cancel Shoot");
        gunBase.StopShoot();
    }
}
