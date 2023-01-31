using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RestartGame()
    {
        DestroyInstances();
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        DestroyInstances();
      SceneManager.LoadScene(0);
    }

    private void DestroyInstances()
    {
        GameController.instance.DestroyInstance();
        EnvironmentController.instance.DestroyInstance();
    }
}
