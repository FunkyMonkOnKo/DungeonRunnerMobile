using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  [SerializeField] private TMP_Text highScoreTextUI;
  [SerializeField] private TMP_Text coinsCountTextUI;

  private void Start()
  {
    float highScore = PlayerPrefs.GetFloat(ScoreController.highScoreHash);
    int coinsCount = PlayerPrefs.GetInt(ScoreController.coinsCountHash);

    highScoreTextUI.text = $"High Score: {Mathf.FloorToInt(highScore).ToString()}";
    coinsCountTextUI.text = $"Coins: {coinsCount.ToString()}";
  }

  public void StartGame()
  {
    SceneManager.LoadScene(1);
  }

  public void PlayerPickerMenu()
  {
    SceneManager.LoadScene(2);
  }
}
