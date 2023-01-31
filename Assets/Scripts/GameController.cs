using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  public static GameController instance;

  [SerializeField] private float startCounterValue;
  [SerializeField] private GameObject gameOverMenu;


  public bool isPaused { get; private set; }
  private bool gameStarted = false;
  public bool gameOver { get; private set; }

  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else
    {
      Destroy(gameObject);
    }
  }

  private void Start()
  {
    isPaused = true;
    gameOver = false;
  }

  private void Update()
  {
    if (startCounterValue > 0)
    {
      startCounterValue -= Time.deltaTime;
      return;
    }

    if (!gameStarted)
    {
      UnpauseGame();
      gameStarted = true;
    }
  }

  public void PauseGame()
  {
    isPaused = true;
  }

  public void UnpauseGame()
  {
    isPaused = false;
  }

  public void GameOver() {
    gameOver = true;
    gameOverMenu.SetActive(true);
  }

    public void DestroyInstance()
    {
        Destroy(instance.gameObject);
        instance = null;
    }
}
