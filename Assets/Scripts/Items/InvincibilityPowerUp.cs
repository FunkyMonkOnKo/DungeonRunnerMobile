using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPowerUp : MonoBehaviour
{
  private float zPosition;
  private float xRotation;

  [SerializeField] private int scoreValue;
  [SerializeField] private ParticleSystem popOutEffect;

  [SerializeField] public float invincibilityDuration;

  void Start()
  {
    zPosition = gameObject.transform.position.z;
  }

  void Update()
  {
    if (GameController.instance != null && !GameController.instance.isPaused)
    {
      zPosition -= EnvironmentController.instance.environmentSpeed * Time.deltaTime;
      gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zPosition);

      xRotation -= EnvironmentController.instance.environmentSpeed * Time.deltaTime;
      gameObject.transform.Rotate(0, xRotation, 0);
    }
  }

  private void OnBecameInvisible()
  {
    Destroy(gameObject);
  }

  public void Collect()
  {
    if (popOutEffect != null)
    {
      Instantiate(popOutEffect, this.transform.position, this.transform.rotation);
    }

    ScoreController.instance.PowerUpPickup(scoreValue);
    Destroy(gameObject);
  }
}
