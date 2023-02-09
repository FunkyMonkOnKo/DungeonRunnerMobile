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
    SceneManager.LoadScene(0);
  }
}
