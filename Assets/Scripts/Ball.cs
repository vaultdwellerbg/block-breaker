using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;

    private Vector2 paddleToBallVector;
    private bool isLaunched = false;


    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    void Update()
    {
        if (isLaunched) return;

        LockBallToPaddle();
        LaunchOnMouseClick();
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnMouseClick() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            isLaunched = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }
}
