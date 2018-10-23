using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float paddleSpeed;
    public float limitLeft = -0.2f;
    public float limitRight = 0.2f;
    public float paddleYPos = .5f;
    private Vector3 playerPos = new Vector3(0, 0, 0);

    private void Update()
    {

        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        playerPos = new Vector3(Mathf.Clamp(xPos, limitLeft, limitRight), paddleYPos, 0f);
        transform.position = playerPos;

    }
}
