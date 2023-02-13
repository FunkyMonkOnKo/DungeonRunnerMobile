using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
  public void BackToMainMenu() {
    AudioManager.instance.PlaySFX(4);
    SceneManager.LoadScene(0);
  }
}
