using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerController : MonoBehaviour
{
  [SerializeField] private GameObject[] lanes;

  [SerializeField] private GameObject[] obstacles;

  [SerializeField] private float spawnTimer;

  private float secondsToSpawn;

  void Start()
  {
    secondsToSpawn = spawnTimer;
  }

  void Update()
  {
    if (!GameController.instance.isPaused) {
      if (secondsToSpawn >= 0)
      {
        secondsToSpawn -= Time.deltaTime;
        return;
      }
      GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)];
      GameObject lane = lanes[Random.Range(0, lanes.Length)];

      secondsToSpawn = spawnTimer;
      Instantiate(obstacle, lane.transform.position, obstacle.transform.rotation);
    }
  }
}
