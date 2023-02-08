using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelPicker : MonoBehaviour
{

  [SerializeField] private string defaultPlayerModelName = "Character_Hero_Knight_Female";

  public const string playerModelNameHash = "CurrentPlayerModel";

  public void SetPlayerModel()
  {
    if (!PlayerPrefs.HasKey(playerModelNameHash))
    {
      PlayerPrefs.SetString(playerModelNameHash, defaultPlayerModelName);
    }

    {
      for (int i = 0; i < gameObject.transform.childCount; i++)
      {
        GameObject playerModel = gameObject.transform.GetChild(i).gameObject;
        if (playerModel.name != PlayerPrefs.GetString(playerModelNameHash))
        {
          playerModel.SetActive(false);
        }
        else
        {
          playerModel.SetActive(true);
        }
      }
    }
  }
}
