using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float timeToMatch = 10f;
    public float currentTimeToMatch = 0;
    public GameState gameState;
    public int Points = 0;
    public UnityEvent OnPointsUpdated;
    public enum GameState
    {
        Idle,
        InGame,
        GameOver
    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance=this;  
        }else
        {
            Destroy(gameObject);
        }
    }

   public void AddPoints(int newPoints)
    {
        Points +=newPoints;
        OnPointsUpdated?.Invoke();
        currentTimeToMatch = 0;
    }
    public void Update()
    {
        if (gameState == GameState.InGame)
        {
            currentTimeToMatch += Time.deltaTime;
            if (currentTimeToMatch > timeToMatch)
            {
                gameState = GameState.GameOver;
            }
        }
    }
}
