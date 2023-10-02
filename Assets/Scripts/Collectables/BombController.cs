using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : CollectableController
{ 
    private void Awake()
    {
        value = 0;
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
        
        if (collider.gameObject.name.Equals("Player"))
        {
            collider.gameObject.GetComponentInChildren<InventoryController>().RemoveItem();
            isCollected = true;
            GameObject.Find("BombSound").GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
