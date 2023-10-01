using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using Random = System.Random;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventorySlot invSlot1,
        invSlot2,
        invSlot3,
        invSlot4,
        invSlot5,
        invSlot6,
        invSlot7,
        invSlot8,
        invSlot9,
        invSlot10,
        invSlot11,
        invSlot12,
        invSlot13,
        invSlot14,
        invSlot15,
        invSlot16;

    private List<InventorySlot> invSlots = new();

    private void Awake()
    {
        invSlots.Add(invSlot1);
        invSlots.Add(invSlot2);
        invSlots.Add(invSlot3);
        invSlots.Add(invSlot4);
        invSlots.Add(invSlot5);
        invSlots.Add(invSlot6);
        invSlots.Add(invSlot7);
        invSlots.Add(invSlot8);
        invSlots.Add(invSlot9);
        invSlots.Add(invSlot10);
        invSlots.Add(invSlot11);
        invSlots.Add(invSlot12);
        invSlots.Add(invSlot13);
        invSlots.Add(invSlot14);
        invSlots.Add(invSlot15);
        invSlots.Add(invSlot16);
    }

    public void StoreItem(CollectableController item)
    {
        item.transform.localScale = new Vector3(3, 3, 3);
        item.GetComponent<SpriteRenderer>().sortingOrder = 7;
        item.GetComponent<SpriteRenderer>().sprite = item.collectedSprite;
        
        foreach (var slot in invSlots)
        {
            if (!slot.hasItem)
            {
                item.transform.position = slot.transform.position;
                slot.hasItem = true;
                break;
            } 
            
        }
    }
}