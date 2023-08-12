using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float forwardSpeed;

    private int desiredLane = 1; // 0:left 1:middle 2:right
    public float laneDistance = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 targetPosition = rb.position;

        if (Input.GetKeyDown(KeyCode.D))
        {
            desiredLane++;
            if (desiredLane > 2)
            {
                desiredLane = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            desiredLane--;
            if (desiredLane < 0)
            {
                desiredLane = 0;
            }
        }

        // Calculate the target X position based on the desired lane
        float targetX = (desiredLane - 1) * laneDistance;
        targetPosition.x = targetX;

        rb.MovePosition(targetPosition);
    }
}