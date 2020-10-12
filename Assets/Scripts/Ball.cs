﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 0f;
    [SerializeField] float yPush = 15f;
    Vector2 paddleToPosVector;
    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        paddleToPosVector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted) {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LockBallToPaddle() {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToPosVector;
    }

    private void LaunchOnMouseClick() {
        Debug.Log("Im on Launch the ball");
        if(Input.GetMouseButtonDown(0)) {
            Debug.Log("I launch the ball");
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush , yPush);
        }
    }
}
