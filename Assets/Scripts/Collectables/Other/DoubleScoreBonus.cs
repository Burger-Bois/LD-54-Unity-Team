using UnityEngine;
using UnityEngine.UI;

public class DoubleScoreBonus : CollectableController, ScoreAffecter
{

    [SerializeField] public BonusTimer timer;
    public float bonusTime = 20f;
    private BonusTimer bonusTimer;

    void Start()
    {
        
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
            bonusTimer.Setup(bonusTime);
        }
    }



}

