using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelPickerButton : MonoBehaviour
{
  [SerializeField] private string modelName;
  public void SelectPlayerModel()
  {
    PlayerPrefs.SetString(PlayerModelPicker.playerModelNameHash, modelName);
  }
}
