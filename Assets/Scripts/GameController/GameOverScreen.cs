using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = $"You Scored " +
                         $"{score}" +
                         $" points";
        Time.timeScale = 0;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }
}
