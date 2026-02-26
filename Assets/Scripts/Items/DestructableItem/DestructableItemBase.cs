using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableItemBase : MonoBehaviour
{

    public HealthBase healthBase;

    public float shakeDuration = .1f;
    public int shakeForce = 1;

    public int dropCoinsAmount = 10;
    public GameObject coinPrefab;
    public Transform dropPosition;

    private void OnValidate()
    {
        if(healthBase == null) healthBase = GetComponent<HealthBase>();
    }

    private void Awake()
    {
        OnValidate();
        healthBase.OnDamage += OnDamage;
    }

    private void OnDamage(HealthBase h)
    {
        transform.DOShakeScale(shakeDuration, Vector3.up/2, shakeForce);
        DropCoin();
    }

    private void DropCoin()
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-0.5f, 0.5f),
            0.5f,
            Random.Range(-0.5f, 0.5f)
        );

        var i = Instantiate(coinPrefab, dropPosition.position + randomOffset, Quaternion.identity);

        i.transform.DOScale(0, 0.3f)
            .From()
            .SetEase(Ease.OutBack);
    }
}
