using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
  public static EnvironmentController instance;

  [SerializeField] private GameObject environmentUnitPrefab;
  [SerializeField] private int unitsOnScene = 4;
  public float environmentSpeed;

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

  void Start()
  {
    int i = 0;

    while (i < unitsOnScene)
    {
      Instantiate(environmentUnitPrefab, new Vector3(0, 0, i * environmentUnitPrefab.GetComponent<BoxCollider>().size.z), environmentUnitPrefab.transform.rotation);
      i++;
    }
  }

  public void GenerateUnit(float relativePositionZ, float unitSize)
  {
    Instantiate(environmentUnitPrefab, new Vector3(0, 0, relativePositionZ + (unitsOnScene * unitSize)), environmentUnitPrefab.transform.rotation);
  }

    public void DestroyInstance()
    {
        Destroy(instance.gameObject);
        instance = null;
    }
}
