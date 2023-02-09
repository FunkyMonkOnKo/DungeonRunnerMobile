using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
  public static ScoreController instance;
  public float score { get; private set; }
  public int coins { get; private set; }

  public const string highScoreHash = "HighScore";
  public const string coinsCountHash = "CoinsCount";

  [SerializeField] private float scoreMultiplier;

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

  void Start()
  {
    score = 0;
    coins = 0;

    if (!PlayerPrefs.HasKey(highScoreHash))
    {
      PlayerPrefs.SetFloat(highScoreHash, 0);
    }

    if (!PlayerPrefs.HasKey(coinsCountHash))
    {
      PlayerPrefs.SetInt(coinsCountHash, 0);
    }
  }

  public void UpdateScore(float scoreToAdd)
  {
    score += scoreToAdd * scoreMultiplier;
  }

  public void CoinPickup(int scoreValue) {
    score += scoreValue * scoreMultiplier;
    coins += 1;
  }

  public void PowerUpPickup(int scoreValue) {
    score += scoreValue * scoreMultiplier;
  }

  public void SaveHighScore() {
    if (PlayerPrefs.GetFloat(highScoreHash) < score)
    {
      PlayerPrefs.SetFloat(highScoreHash, score);
    }   
  }

  public void AddCoinsToPlayer() {
    int actualCoins = PlayerPrefs.GetInt(coinsCountHash);
    PlayerPrefs.SetInt(coinsCountHash, actualCoins + coins);
  }

  public void NullScore() {
    score = 0;
    coins = 0;
  }

  public void DestroyInstance()
  {
    Destroy(instance.gameObject);
    instance = null;
  }
}
