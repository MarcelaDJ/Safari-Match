using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    public int displayedPoints = 0;
    public TextMeshProUGUI pointsUI;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
    }

    private void GameStateUpdated(GameManager.GameState newState)
    {
        if (newState == GameManager.GameState.GameOver)
        {
            displayedPoints = 0;
            StartCoroutine(DisplayPointsCoroutine());
        }
    }

    IEnumerator DisplayPointsCoroutine()
    {
        while (displayedPoints < GameManager.Instance.Points)
        {
            displayedPoints++;
            pointsUI.text = displayedPoints.ToString();
            yield return new WaitForFixedUpdate();
        }
        displayedPoints = GameManager.Instance.Points;
        pointsUI.text = displayedPoints.ToString();
        yield return null;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStateUpdated.RemoveListener(GameStateUpdated);
    }
     public void ExitGameBtnClicked()
    {
        GameManager.Instance.ExitGame();
    }

    public void PlayAgainBtnClicked()
    {
        GameManager.Instance.RestartGame();
    }
}
