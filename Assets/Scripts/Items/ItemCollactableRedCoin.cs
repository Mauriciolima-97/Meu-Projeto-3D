using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableRedCoin : ItemCollactableBase
{
    public Collider2D colliderRed;

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddRedCoins();
        colliderRed.enabled = false;
    }

}
