using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI totalScoreText,
        bonusScoreText,
        diamondScoreText,
        rubyScoreText,
        emeraldScoreText,
        amethystScoreText,
        topazScoreText,
        rockScoreText;


    public void Setup(int baseScore, int bonusScore, int diamondCount, int rubyCount, int emeraldCount, int amethystCount,
        int topazCount, int rockCount)
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);

        diamondScoreText.text =
            BuildSubscoreText(new GameObject("DiamondScoreObj", typeof(DiamondController)), diamondCount);
        rubyScoreText.text = BuildSubscoreText(new GameObject("RubyScoreObj", typeof(RubyController)), rubyCount);
        emeraldScoreText.text =
            BuildSubscoreText(new GameObject("EmeraldScoreObj", typeof(EmeraldController)), emeraldCount);
        amethystScoreText.text =
            BuildSubscoreText(new GameObject("AmethystScoreObj", typeof(AmethystController)), amethystCount);
        topazScoreText.text = BuildSubscoreText(new GameObject("TopazScoreObj", typeof(TopazController)), topazCount);
        rockScoreText.text = BuildSubscoreText(new GameObject("RockScoreObj", typeof(RockController)), rockCount);


        if (bonusScore >= 0)
        {
            bonusScoreText.color = Color.green;
        } 
        else
        {
            bonusScoreText.color = Color.red;
        }

        bonusScoreText.text = bonusScore.ToString(); 

        var totalScore = baseScore + bonusScore;
        totalScoreText.text = $"You Scored \n" +
                              $"{totalScore} \n" +
                              $" points";
    }


    private string BuildSubscoreText(GameObject collectable, int count)
    {
        int value = collectable.GetComponent<CollectableController>().value;
        int subScore = count * value;
        return value + " x " + count + " = " + subScore;
    }
}