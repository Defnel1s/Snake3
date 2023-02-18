using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 startGamePosition;
    Quaternion startGameRotation;
    Vector3 targetPos;
    float laneOffset = 4.8f;
    float laneChangeSpeed = 19;
     void Start()
    {
        startGamePosition = transform.position;
        startGameRotation = transform.rotation;
        targetPos = transform.position;
    }
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && targetPos.x > -laneOffset)
        {
            targetPos = new Vector3(targetPos.x - laneOffset, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D) && targetPos.x < laneOffset)
        {
            targetPos = new Vector3(targetPos.x + laneOffset, transform.position.y, transform.position.z);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPos, laneChangeSpeed * Time.deltaTime);
    }
    public void StartGame()
    {
        RoadGenerator.instance.StartLevel();
    }
    public void ResetGame()
    {
        RoadGenerator.instance.ResetLevel();
        transform.position = startGamePosition;
        transform.rotation = startGameRotation;
    }
}
