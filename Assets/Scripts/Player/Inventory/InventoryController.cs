using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryUI UI;
    
    private List<CollectableController> inventory = new();
    private int score = 0;
   
    public bool isFull = false;
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
            isFull = true;
        }
    }

    private void Update()
    {
        if (isFull)
        {
            gameOverScreen.Setup(GetScore());
        }
    }

    public int GetScore()
    {
        return score;
    }
}
