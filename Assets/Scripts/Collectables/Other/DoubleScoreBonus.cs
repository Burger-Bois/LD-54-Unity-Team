using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoubleScoreBonus : CollectableController, ScoreAffecter
{
    private BonusTimer bonusTimer;
    
    public float bonusTime = 15f;
    
    private void Awake()
    {
        bonusTimer = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().bonusTimer;
    }

    public int CalculateScoreBonus(int initialScore)
    {
        return initialScore;
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);

        if (collider.gameObject.name.Equals("Player"))
        {
            Destroy(gameObject);
            GameObject.Find("CoinSound").GetComponent<AudioSource>().Play();
            bonusTimer.Setup(bonusTime);
        }
    }



}

