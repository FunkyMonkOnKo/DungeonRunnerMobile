using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private Animator playerAnim;
  [SerializeField] private float speed;

  const string turnLeft = "TurnLeft";
  const string turnRight = "TurnRight";
  const string collision = "Collision";

  private GameObject[] lanes;

  private bool isRunning = false;
  private int horizontalInput = 0;

  [SerializeField] private Light playerAura;
  [SerializeField] private float flashLenght;
  private float flashCounter;

  private float invincibiltyRemains;
  private bool isInvincible = false;

  private bool isMovingBetweenLanes;
  private int laneNum;

  [SerializeField] private PlayerModelPicker avatar;


  void Start()
  {
    lanes = SpawnerController.instance.lanes;

    laneNum = 1;
    isMovingBetweenLanes = false;

    invincibiltyRemains = 0;

    avatar.SetPlayerModel();
  }


  void Update()
  {
    if (GameController.instance != null && !GameController.instance.isPaused)
    {
      if (isInvincible && invincibiltyRemains > 0)
      {
        invincibiltyRemains -= Time.deltaTime;
        flashCounter -= Time.deltaTime;

        if (invincibiltyRemains < 3 && flashCounter >= 0) {
          playerAura.enabled = !playerAura.enabled;
          flashCounter = flashLenght;
        }
      }
      else if (isInvincible && invincibiltyRemains <= 0)
      {
        DisableInvincibilty();
      }

      if (!isRunning)
      {
        playerAnim.SetTrigger("StartRunning");
        isRunning = true;
      }

      if (isMovingBetweenLanes)
      {
        MovePlayer(laneNum);
        return;
      }

      if ((horizontalInput == -1 || Input.GetAxisRaw("Horizontal") == -1f) && laneNum < lanes.Length - 1)
      {
        playerAnim.SetTrigger(turnLeft);
        StartCoroutine(MovePlayerBetweenLanes(turnLeft));
        horizontalInput = 0;
      }
      else if ((horizontalInput == 1 || Input.GetAxisRaw("Horizontal") == 1f) && laneNum > 0)
      {
        playerAnim.SetTrigger(turnRight);
        StartCoroutine(MovePlayerBetweenLanes(turnRight));
        horizontalInput = 0;
      }
    }
  }

  IEnumerator MovePlayerBetweenLanes(string direction)
  {
    SelectNewLanePosition(direction);
    isMovingBetweenLanes = true;

    yield return new WaitForSeconds(0.7f);

    isMovingBetweenLanes = false;
  }

  private void MovePlayer(int lanePos)
  {
    Vector3 lanePosition = new Vector3(lanes[lanePos].transform.position.x, 0, 0);
    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, lanePosition, speed * Time.deltaTime);
  }

  private void SelectNewLanePosition(string direction)
  {
    switch (direction)
    {
      case turnLeft:
        laneNum++;
        if (laneNum > lanes.Length - 1)
          laneNum = lanes.Length - 1;
        break;
      case turnRight:
        laneNum--;
        if (laneNum < 0)
          laneNum = 0;
        break;
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Obstacle")
    {

      Obstacle obstacle = other.GetComponent<Obstacle>();
      obstacle.PopOut();

      if (!isInvincible)
      {
        GameController.instance.PauseGame();
        playerAnim.SetTrigger(collision);
        StartCoroutine(PlayerDefeat());
      }
    }
    else if (other.tag == "Coin")
    {
      Coin coin = other.GetComponent<Coin>();
      coin.Collect();
    }
    else if (other.tag == "PowerUp")
    {
      InvincibilityPowerUp powerup = other.GetComponent<InvincibilityPowerUp>();
      powerup.Collect();

      EnableInvincibilty(powerup.invincibilityDuration);
    }
  }

  IEnumerator PlayerDefeat()
  {
    yield return new WaitForSeconds(1f);
    GameController.instance.GameOver();
  }

  public void MoveHorizontalPlayer(int value)
  {
    horizontalInput = value;
  }

  private void DisableInvincibilty()
  {
    isInvincible = false;
    playerAura.color = Color.white;
    playerAura.intensity = 1.5f;
  }

  private void EnableInvincibilty(float duration)
  {
    invincibiltyRemains = duration;
    isInvincible = true;
    playerAura.color = Color.red;
    playerAura.intensity = 3;
  }
}
