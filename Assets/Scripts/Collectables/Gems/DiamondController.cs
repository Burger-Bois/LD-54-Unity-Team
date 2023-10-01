using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiamondController : CollectableController
{
    private void Awake()
    {
        value = 50;
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
        
        if (collider.gameObject.name.Equals("Player"))
        {
            collider.gameObject.GetComponentInChildren<InventoryController>().AddItem(this);
            isCollected = true;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}