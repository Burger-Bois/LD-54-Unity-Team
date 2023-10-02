using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryUI UI;
    
    private List<CollectableController> inventory = new();
   
    public GameOverScreen gameOverScreen;
    public ScoreManager scoreManager;

    private void Awake()
    {
        inventory.Capacity = 16;
    }

    public void AddItem(CollectableController item)
    {

        if (scoreManager.GetComponent<ScoreManager>().bonusTimer.isActive)
        {
            item.scoreAffecter = new GameObject("DoubleScoreBonus-" + item.name, typeof(DoubleScoreBonus)).GetComponent<DoubleScoreBonus>();
        }
        inventory.Add(item);
        UI.StoreItem(item);

        if (inventory.Count == inventory.Capacity)
        {
            var diamondCount = inventory.FindAll(c => c is DiamondController).Count;
            var rubyCount = inventory.FindAll(c => c is RubyController).Count;
            var emeraldCount = inventory.FindAll(c => c is EmeraldController).Count;
            var amethystCount = inventory.FindAll(c => c is AmethystController).Count;
            var topazCount = inventory.FindAll(c => c is TopazController).Count;
            var rockCount = inventory.FindAll(c => c is RockController).Count;


            gameOverScreen.Setup(GetBaseScore(), GetBonusScore(), diamondCount, rubyCount, emeraldCount, amethystCount, topazCount, rockCount);
        }
    }

    public int GetBaseScore()
    {
        var score = 0;
        foreach(CollectableController item in inventory) {
            score += item.value;
        }
        return score;
    }

    public int GetBonusScore()
    {
        var score = 0;
        foreach (CollectableController item in inventory)
        {
            if (item.HasScoreAffector())
            {
                score += item.scoreAffecter.CalculateScoreBonus(item.value);
            }
        }
    public void RemoveItem()
    {
        if (inventory.Count > 0)
        {
            var index = inventory.Count - 1;
            inventory.RemoveAt(index);
            UI.RemoveItem(index);
        }
    }

}
