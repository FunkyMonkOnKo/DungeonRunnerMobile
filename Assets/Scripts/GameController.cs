using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  public static GameController instance;


  [SerializeField] private float startCounterValue;
  private float startCounter;

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

    startCounter = startCounterValue;

    AudioManager.instance.PlayLevelMusic();
  }

  private void Update()
  {
    if (startCounter > 0)
    {
      startCounter -= Time.deltaTime;
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
    ScoreController.instance.SaveHighScore();
    ScoreController.instance.AddCoinsToPlayer();
  }

  public void DestroyInstances()
  {
    EnvironmentController.instance.DestroyInstance();
    SpawnerController.instance.DestroyInstance();
    ScoreController.instance.DestroyInstance();

    Destroy(instance.gameObject);
    instance = null;
  }

  public void RestartGame()
  {
    EnvironmentController.instance.DestroyInstance();
    SpawnerController.instance.DestroyInstance();

    ScoreController.instance.NullScore();

    Destroy(instance.gameObject);
    instance = null;
  }
}
