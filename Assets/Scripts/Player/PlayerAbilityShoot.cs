using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{

    public GunBase gunBase1;
    public GunBase gunBase2;
    public Transform gunPosition;

    private GunBase _currentGun;

    protected override void Init()
    {
        base.Init();

        SwitchGun(gunBase1);

        inputs.Gameplay.Shoot.performed += cts => StartShoot();
        inputs.Gameplay.Shoot.canceled += cts => CancelShoot();
    }

   
    private void SwitchGun(GunBase newGun)
    {
        if (_currentGun != null)
        {
            Destroy(_currentGun.gameObject);
        }
        _currentGun = Instantiate(newGun, gunPosition);
        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
    }

    private void StartShoot()
    {
        if (_currentGun != null)
        {
            _currentGun.StartShoot();
            Debug.Log("Shoot");
        }
    }

    private void CancelShoot()
    {
        if (_currentGun != null)
        {
            Debug.Log("CancelShoot");
            _currentGun.StopShoot();
        }
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchGun(gunBase1);
        }

        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchGun(gunBase2);
        }
    }
}
