using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GemController : CollectableController
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public int value = 1;
    
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
        
        if (collider.gameObject.name.Equals("Player"))
        {
            collider.gameObject.GetComponentInChildren<InventoryController>().AddItem(this);
            isCollected = true;
        }
    }
}
