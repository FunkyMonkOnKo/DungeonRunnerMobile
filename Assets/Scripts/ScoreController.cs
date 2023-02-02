using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
  public static ScoreController instance;
  public float score { get; private set; }
  public int coins { get; private set; }

  [SerializeField] private float scoreMultiplier;

  [SerializeField] private TMP_Text scoreTextUI;
  [SerializeField] private TMP_Text coinsTextUI;

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
  }

  void Update()
  {
    if (GameController.instance != null && !GameController.instance.isPaused)
    {
      score += scoreMultiplier * Time.deltaTime;
    }

    scoreTextUI.text = $"Score: {Mathf.FloorToInt(score).ToString()}";
    coinsTextUI.text = $"X {coins.ToString()}";
  }

  public void CoinPickup(int scoreValue) {
    score += scoreValue;
    coins += 1;
  }

  public void PowerUpPickup(int scoreValue) {
    score += scoreValue;
  }

  public void DestroyInstance()
  {
    Destroy(instance.gameObject);
    instance = null;
  }
}
