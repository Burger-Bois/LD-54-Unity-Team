using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryUI UI;
    
    private List<CollectableController> inventory = new();
    private int score = 0;
   
    public GameOverScreen gameOverScreen;

    private void Awake()
    {
        inventory.Capacity = 16;
    }

    public void AddItem(CollectableController item)
    {
        inventory.Add(item);
        UI.StoreItem(item);
        score += item.gameObject.GetComponent<CollectableController>().value;

        if (inventory.Count == inventory.Capacity)
        {
            var diamondCount = inventory.FindAll(c => c is DiamondController).Count;
            var rubyCount = inventory.FindAll(c => c is RubyController).Count;
            var emeraldCount = inventory.FindAll(c => c is EmeraldController).Count;
            var amethystCount = inventory.FindAll(c => c is AmethystController).Count;
            var topazCount = inventory.FindAll(c => c is TopazController).Count;
            var rockCount = inventory.FindAll(c => c is RockController).Count;


            gameOverScreen.Setup(GetScore(), diamondCount, rubyCount, emeraldCount, amethystCount, topazCount, rockCount);
        }
    }

    public void RemoveItem()
    {
        if (inventory.Count > 0)
        {
            inventory.RemoveAt(inventory.Count - 1);
            UI.RemoveItem();
        }
    }

    public int GetScore()
    {
        return score;
    }
}
