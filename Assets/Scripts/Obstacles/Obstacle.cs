using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
  [SerializeField] private ParticleSystem popOutEffect;
  private float zPosition;

  void Start()
  {
    zPosition = gameObject.transform.position.z;
  }

  void Update()
  {
    if (!GameController.instance.isPaused)
    {
      zPosition -= EnvironmentController.instance.environmentSpeed * Time.deltaTime;
      gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zPosition);
    }
  }

  private void OnBecameInvisible()
  {
    Destroy(gameObject);
  }

  public void PopOut()
  {
    if (popOutEffect != null)
    {
      Instantiate(popOutEffect, this.transform.position, this.transform.rotation);
      Destroy(gameObject);
    }
  }
}
