using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerModelPickerButton : MonoBehaviour
{
  [SerializeField] private string modelName;
  public int modelPrice;
  public bool isUnlocked = false;

  [SerializeField] private Button unlockButton;

  private void Start()
  {
    if (PlayerPrefs.HasKey(name) || modelPrice <= 0) {
      isUnlocked = true;     
    }

    UpdateUnlocks();
  }

  public void UnlockCharacter() {
    int actualCoins = PlayerPrefs.GetInt(ScoreController.coinsCountHash);

    PlayerPrefs.SetInt(ScoreController.coinsCountHash, actualCoins - modelPrice);
    PlayerPrefs.SetInt(name, 1);

    isUnlocked = true;

    AudioManager.instance.PlaySFX(4);

    UpdateUnlocks();
  }

  private void UpdateUnlocks() {

    if (!isUnlocked)
    {
      GetComponent<Button>().interactable = false;

      unlockButton.interactable = true;
      unlockButton.GetComponentInChildren<TMP_Text>().text = $"x {modelPrice.ToString()}";

      if (PlayerPrefs.GetInt(ScoreController.coinsCountHash) < modelPrice)
      {
        unlockButton.interactable = false;
      }

    }
    else
    {
      GetComponent<Button>().interactable = true;
      unlockButton.gameObject.SetActive(false);
    }
  }
}
