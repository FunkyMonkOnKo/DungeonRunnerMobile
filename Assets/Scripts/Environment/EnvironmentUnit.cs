using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentUnit : MonoBehaviour
{
  [SerializeField] private float environmentSpeed;
  [SerializeField] private GameController gameController;

  private float zPosition;

  void Start()
  {
    zPosition = gameObject.transform.position.z;
  }

  void Update()
  {
      if (!gameController.isPaused) { 
        zPosition -= environmentSpeed * Time.deltaTime;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zPosition);
    }
  }
}
