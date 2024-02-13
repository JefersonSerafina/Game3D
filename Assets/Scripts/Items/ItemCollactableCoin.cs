using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Itens;

public class ItemCollactableCoin : ItemCollactableBase
{
    public Collider2D collider2;

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddByType(ItemType.COIN);
        collider2.enabled = false;
    }
}
