using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
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
}
