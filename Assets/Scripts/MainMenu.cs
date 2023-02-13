using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
  [SerializeField] private TMP_Text highScoreTextUI;
  [SerializeField] private TMP_Text coinsCountTextUI;

  [SerializeField] private Button MuteButton;
  [SerializeField] private Sprite MuteOnImage;
  [SerializeField] private Sprite MuteOffImage;
  bool isMute;

  private void Start()
  {
    float highScore = PlayerPrefs.GetFloat(ScoreController.highScoreHash);
    int coinsCount = PlayerPrefs.GetInt(ScoreController.coinsCountHash);

    highScoreTextUI.text = $"High Score: {Mathf.FloorToInt(highScore).ToString()}";
    coinsCountTextUI.text = $"Coins: {coinsCount.ToString()}";

    AudioManager.instance.PlayMainMenuMusic();
  }

  public void StartGame()
  {
    AudioManager.instance.PlaySFX(4);
    SceneManager.LoadScene(1);
  }

  public void PlayerPickerMenu()
  {
    AudioManager.instance.PlaySFX(4);
    SceneManager.LoadScene(2);
  }

  public void Credits()
  {
    AudioManager.instance.PlaySFX(4);
    SceneManager.LoadScene(3);
  }

  public void Mute()
  {
    isMute = !isMute;
    AudioListener.volume = isMute ? 0 : 1;

    MuteButton.GetComponent<Image>().sprite = isMute ? MuteOnImage : MuteOffImage;
  }

  public void DeletePlayerPrefs()
  {
    PlayerPrefs.DeleteAll();
    PlayerPrefs.SetInt(ScoreController.coinsCountHash,150);
  }
}
