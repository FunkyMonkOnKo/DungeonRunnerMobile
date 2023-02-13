using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  public static AudioManager instance;

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

  public AudioSource mainMenuMusic, levelMusic;

  public AudioSource[] sfx;

  public void PlayMainMenuMusic()
  {
    levelMusic.Stop();

    mainMenuMusic.Play();
  }

  public void PlayLevelMusic()
  {
    if (!levelMusic.isPlaying)
    {
      mainMenuMusic.Stop();

      levelMusic.Play();
    }
  }

  public void PlayFootStepsLoop() {
    sfx[5].Play();
  }

  public void StopFootStepsLoop()
  {
    sfx[5].Stop();
  }

  public void PlaySFX(int sfxToPlay)
  {
    sfx[sfxToPlay].Stop();
    sfx[sfxToPlay].Play();
  }

  public void PlaySFXAdjusted(int sfxToAdjust)
  {
    sfx[sfxToAdjust].pitch = Random.Range(.8f, 1.2f);
    PlaySFX(sfxToAdjust);

  }
}