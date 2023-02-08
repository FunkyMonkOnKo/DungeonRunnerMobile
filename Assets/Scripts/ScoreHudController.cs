using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHudController : MonoBehaviour
{
  [SerializeField] private TMP_Text scoreTextUI;
  [SerializeField] private TMP_Text coinsTextUI;

  void Start()
  {

  }

  void Update()
  {
    if (ScoreController.instance != null && GameController.instance != null && !GameController.instance.isPaused)
    {
      ScoreController.instance.UpdateScore(Time.deltaTime);

      scoreTextUI.text = $"Score: {Mathf.FloorToInt(ScoreController.instance.score).ToString()}";
      coinsTextUI.text = $"x {ScoreController.instance.coins.ToString()}";
    }
  }
}
