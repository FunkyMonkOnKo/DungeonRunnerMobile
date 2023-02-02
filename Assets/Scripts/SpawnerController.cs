using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
  public static SpawnerController instance;

  public GameObject[] lanes;
  
  [SerializeField] private GameObject[] obstacles;

  [SerializeField] private GameObject coin;
  [SerializeField] private GameObject invincibilityPowerUp;

  [SerializeField] private float spawnObstacleTimer;
  [SerializeField] private float minSpawnObstacleTimer;
  [SerializeField] private float spawnObstacleTimerMultiplier;
  [SerializeField] private float addDifficultyInterval;

  private float secondsToAddDifficutlty;

  [SerializeField] private float spawnCoinsTimer;
  [SerializeField] private float spawnPowerUpTimer;

  private float secondsToSpawnObstacle;
  private float secondsToSpawnCoins;
  private float secondsToSpawnPowerUp;

  private int obstacleLaneIndex = 0;
  private int coinsLaneIndex = 1;
  private int powerUpLaneIndex = 2;

  private List<int> unoccupiedLanesList = new List<int> {};

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
    secondsToAddDifficutlty = addDifficultyInterval;

    secondsToSpawnObstacle = spawnObstacleTimer;
    secondsToSpawnCoins = spawnCoinsTimer;
    secondsToSpawnPowerUp = spawnPowerUpTimer;

    unoccupiedLanesList.Add(obstacleLaneIndex);
    unoccupiedLanesList.Add(coinsLaneIndex);
    unoccupiedLanesList.Add(powerUpLaneIndex);
  }

  void Update()
  {
    if (GameController.instance != null && !GameController.instance.isPaused)
    {
      if (secondsToAddDifficutlty >= 0)
      { secondsToAddDifficutlty -= Time.deltaTime; }
      else if (spawnObstacleTimer > minSpawnObstacleTimer)
      { AddDifficulty(); }

      if (secondsToSpawnObstacle >= 0)
      { secondsToSpawnObstacle -= Time.deltaTime; }
      else
      { SpawnObstacle(); }

      if (secondsToSpawnCoins >= 0)
      { secondsToSpawnCoins -= Time.deltaTime; }
      else
      { SpawnCoins(); }

      if (secondsToSpawnPowerUp >= 0)
      { secondsToSpawnPowerUp -= Time.deltaTime; }
      else
      { SpawnPowerUp(); }
    }
  }

  private void AddDifficulty()
  {
    spawnObstacleTimer /= spawnObstacleTimerMultiplier;
    secondsToAddDifficutlty = addDifficultyInterval;
  }

  private void SpawnObstacle()
  {
    if (!unoccupiedLanesList.Contains(obstacleLaneIndex)) { unoccupiedLanesList.Add(obstacleLaneIndex); }

    GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)];
    obstacleLaneIndex = ChooseRandomUnoccupiedIndex();
    unoccupiedLanesList.Remove(obstacleLaneIndex);
    GameObject lane = lanes[obstacleLaneIndex];

    secondsToSpawnObstacle = spawnObstacleTimer;
    Instantiate(obstacle, lane.transform.position, obstacle.transform.rotation);
  }

  private void SpawnCoins()
  {
    if (!unoccupiedLanesList.Contains(coinsLaneIndex)) { unoccupiedLanesList.Add(coinsLaneIndex); }

    coinsLaneIndex = ChooseRandomUnoccupiedIndex();
    unoccupiedLanesList.Remove(coinsLaneIndex);
    GameObject lane = lanes[coinsLaneIndex];

    secondsToSpawnCoins = spawnCoinsTimer;

    int coinCount = Random.Range(1, 5);
    Vector3 coinPosition = lane.transform.position;
    while (coinCount > 0) {
      coinPosition.z += coinCount;
      Instantiate(coin, coinPosition, coin.transform.rotation);
      coinCount--;
    }
  }

  private void SpawnPowerUp()
  {
    if (!unoccupiedLanesList.Contains(powerUpLaneIndex)) { unoccupiedLanesList.Add(powerUpLaneIndex); }

    powerUpLaneIndex = ChooseRandomUnoccupiedIndex();
    unoccupiedLanesList.Remove(powerUpLaneIndex);
    GameObject lane = lanes[powerUpLaneIndex];

    secondsToSpawnPowerUp = spawnPowerUpTimer;
    Instantiate(invincibilityPowerUp, lane.transform.position, invincibilityPowerUp.transform.rotation);
  }

  private int ChooseRandomUnoccupiedIndex()
  {
    System.Random random = new System.Random();
    int index = random.Next(unoccupiedLanesList.Count);
    return index;
  }

  public void DestroyInstance()
  {
    Destroy(instance.gameObject);
    instance = null;
  }
}
