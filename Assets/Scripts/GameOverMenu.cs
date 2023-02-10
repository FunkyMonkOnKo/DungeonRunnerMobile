using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
  public void RestartGame()
  {
    AdsManager.instance.LoadAd();
    AdsManager.instance.ShowAd();
  }

  public void BackToMenu()
  {
    GameController.instance.DestroyInstances();
    SceneManager.LoadScene(0);
  }
}
