using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class FinishGameManager : MonoBehaviour
{
    public static FinishGameManager Instance;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI youLostText;

    public const string prefHighScore = "prefHighScore";

    private void Awake()
    {
        Instance = this;
    }

    public void FinishGame()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);

        bool isNewHighScore = ScoreManager.Instance.CheckNewHighScore();
        if (isNewHighScore)
        {
            PlayerPrefs.SetInt(prefHighScore, ScoreManager.Instance.NewHighScore());
            youLostText.text = "HighScore: " + ScoreManager.Instance.NewHighScore();
        }
        else
        {
            youLostText.text = "HighScore: " + PlayerPrefs.GetInt("prefHighScore");
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
