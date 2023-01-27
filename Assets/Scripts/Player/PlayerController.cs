using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private Animator playerAnim;
  [SerializeField] private float speed;
  [SerializeField] private float startCounterValue;

  const string turnLeft = "TurnLeft";
  const string turnRight = "TurnRight";

  private Vector3[] lanes = new Vector3[3];
  private Vector3 leftLane = new Vector3(2, 0, 0);
  private Vector3 midLane = new Vector3(0, 0, 0);
  private Vector3 rightLane = new Vector3(-2, 0, 0);

  [SerializeField] private bool isMovingBetweenLanes;
  [SerializeField] private int lanePos;


  void Start()
  {
    lanes[0] = leftLane;
    lanes[1] = midLane;
    lanes[2] = rightLane;

    lanePos = 1;
    isMovingBetweenLanes = false;
  }

  void Update()
  {
    if (startCounterValue > 0)
    {
      startCounterValue -= Time.deltaTime;
      return;
    }

    playerAnim.SetTrigger("StartRunning");

    if (isMovingBetweenLanes)
    {
      MovePlayer(lanePos);
      return;
    }


    if (Input.GetAxisRaw("Horizontal") == -1f && lanePos < lanes.Length - 1)
    {
      playerAnim.SetTrigger(turnLeft);
      StartCoroutine(MovePlayerBetweenLanes(turnLeft));
    }
    else if (Input.GetAxisRaw("Horizontal") == 1f && lanePos > 0)
    {
      playerAnim.SetTrigger(turnRight);
      StartCoroutine(MovePlayerBetweenLanes(turnRight));
    }
  }

  IEnumerator MovePlayerBetweenLanes(string direction)
  {
    SelectNewLanePosition(direction);
    isMovingBetweenLanes = true;

    yield return new WaitForSeconds(1f);

    isMovingBetweenLanes = false;
  }

  private void MovePlayer(int lanePos)
  {
    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, lanes[lanePos], speed * Time.deltaTime);
  }

  private void SelectNewLanePosition(string direction)
  {
    switch (direction)
    {
      case turnLeft:
        lanePos++;
        if (lanePos > lanes.Length - 1)
          lanePos = lanes.Length - 1;
        break;
      case turnRight:
        lanePos--;
        if (lanePos < 0)
          lanePos = 0;
        break;
    }
  }
}
