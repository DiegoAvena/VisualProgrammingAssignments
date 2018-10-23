using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerMovement : MonoBehaviour {

    public GameObject ballToFollow;
    private Vector2 ballPosition;
    private Rigidbody2D rgbd;

    public float computerSpeed = 10;

	// Use this for initialization
	void Start () {

        rgbd = GetComponent<Rigidbody2D>();
        ballPosition = ballToFollow.gameObject.transform.position;

	}

    private void ResetPosition() {

        transform.position = new Vector2(transform.position.x, 0);

    }
	
    private void KeepEnemyEyeOnPongBall() {

        if (ballPosition.x >= 1.2) {

            if ((int)transform.position.y > (int)ballPosition.y) {

                rgbd.velocity = new Vector2(0, -computerSpeed);

            }
            else if ((int)transform.position.y < (int)ballPosition.y) {

                rgbd.velocity = new Vector2(0, computerSpeed);

            }
            else {

                rgbd.velocity = new Vector2(0, 0);

            }

        }
        else {

            rgbd.velocity = new Vector2(0, 0);

        }


    }

	// Update is called once per frame
	void Update () {

        ballPosition = ballToFollow.gameObject.transform.position;
        KeepEnemyEyeOnPongBall();

    }

}
