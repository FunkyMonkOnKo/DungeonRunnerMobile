using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerModelPickerMenu : MonoBehaviour
{
  public void SelectPlayerModel(string modelName)
  {
    PlayerPrefs.SetString(PlayerModelPicker.playerModelNameHash, modelName);
  }

  public void BackToMenu()
  {
    AudioManager.instance.PlaySFX(4);
    SceneManager.LoadScene(0);
  }
}
