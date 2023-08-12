using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public const string prefScore = "prefScore";

    [SerializeField] private TextMeshProUGUI scoreText;
    private float score;
    private bool isTraveling;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (!isTraveling)
        {
            return;
        }

        score += Time.deltaTime;
        scoreText.text = "score: " + (int)score;
    }

    public void StartScript()
    {
        isTraveling = true;
    }

    public bool CheckNewHighScore()
    {
        if ((int)score > PlayerPrefs.GetInt("prefScore"))
        {
            //new highscore
            PlayerPrefs.SetInt(prefScore, (int)score);
            Debug.Log("New highscore: " + (int)score);
            return true;
        }
        else
        {
            //no new highscore
            Debug.Log("No new highscore");
            return false;
        }
    }
    public int NewHighScore()
    {
        return (int)score;
    }
}