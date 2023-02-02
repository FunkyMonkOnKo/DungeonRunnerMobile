using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentUnit : MonoBehaviour
{
  private float zPosition;
  public float unitSize { get; private set; }

  private void Awake()
  {
    SetUnitSize();
  }

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
    }
  }

  private void FixedUpdate()
  {
    if (gameObject.transform.position.z <= -unitSize * 2)
    {
      EnvironmentController.instance.GenerateUnit(gameObject.transform.position.z, unitSize);
      Destroy(gameObject);
    }
  }

  private void SetUnitSize() { unitSize = GetComponent<BoxCollider>().size.z; }

  public float GetUnitSize() { return unitSize; }
}
