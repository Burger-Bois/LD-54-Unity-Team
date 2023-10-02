using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoubleScoreBonus : CollectableController, ScoreAffecter
{
    private BonusTimer bonusTimer;
    
    public float bonusTime = 20f;
    
    private void Awake()
    {
        bonusTimer = GameObject.Find("ScoreManager").GetComponent<ScoreManger>().bonusTimer;
    }

    public int calculateScoreBonus(int initialScore)
    {
        var bonus = 0;
        if(bonusTimer.isActive)
        {
            bonus = initialScore;
        }
        return bonus;
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);

        if (collider.gameObject.name.Equals("Player"))
        {
            Destroy(gameObject);
            bonusTimer.Setup(bonusTime);
        }
    }



}

