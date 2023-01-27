using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  public static GameController instance;

  public bool isPaused { get; private set; }

  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else
    {
      Destroy(gameObject);
    }
  }

  private void Start()
  {
    isPaused = true;
  }

  public void PauseGame() {
    isPaused = true;
  }

  public void UnpauseGame() {
    isPaused = false;
  }
}
