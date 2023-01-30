using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentUnit : MonoBehaviour
{
  [SerializeField] private float environmentSpeed;

  private float zPosition;
  public float UnitSize { get; private set; }

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
    if (!GameController.instance.isPaused) {
      zPosition -= environmentSpeed * Time.deltaTime;
      gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zPosition);
    }
  }

  private void FixedUpdate()
  {
    if (gameObject.transform.position.z <= -UnitSize)
    {
      EnvironmentController.instance.GenerateUnit(gameObject.transform.position.z, UnitSize);
      Destroy(gameObject);
    }
  }

  private void SetUnitSize() { UnitSize = GetComponent<BoxCollider>().size.z; }

  public float GetUnitSize() { return UnitSize; }
}
