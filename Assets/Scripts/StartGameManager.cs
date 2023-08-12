using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    void Update()
    {
        StartGame();
    }

    private void StartGame()
    {
        SpawnManager.Instance.StartScript();
        ScoreManager.Instance.StartScript();
        enabled = false;
    }
}
