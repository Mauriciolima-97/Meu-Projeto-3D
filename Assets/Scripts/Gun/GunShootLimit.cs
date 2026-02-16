using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunShootLimit : GunBase
{
    public List<UIGunUpdater> uIGunUpdaters;

    public float maxShoot = 5f;
    public float timeToRecharge = 1f;

    private float _currentShoots;
    private bool _recharging = false;

    protected override void Awake()
    {
        base.Awake();

        if (uIGunUpdaters == null || uIGunUpdaters.Count == 0)
        {
            uIGunUpdaters = FindObjectsOfType<UIGunUpdater>().ToList();
        }
    }


    protected override IEnumerator ShootCoroutine()
    {
        if (_recharging) yield break;

        while (_currentShoots < maxShoot)
        {
            Shoot();

            _currentShoots++;

            UpdateUI();

            yield return new WaitForSeconds(timeBetweenShoot);

        }

        StartRecharge();
    }

    private void StartRecharge()
    {
        if (_recharging) return;

        _recharging = true;
        StopShoot();
        StartCoroutine(RechargeCoroutine());
    }

    IEnumerator RechargeCoroutine()
    {
        float time = 0;

        while (time < timeToRecharge)
        {
            time += Time.deltaTime;

            float normalized = time / timeToRecharge;

            uIGunUpdaters.ForEach(i => i.UpdateRecharge(normalized));

            yield return null;
        }

        _currentShoots = 0;
        _recharging = false;

        UpdateUI();
    }

    private void UpdateUI()
    {
        uIGunUpdaters.ForEach(i => i.UpdateValue(maxShoot, _currentShoots));
    }

    private void GetAllUIs()
    {
        uIGunUpdaters = FindObjectsOfType<UIGunUpdater>().ToList();
    }
}
