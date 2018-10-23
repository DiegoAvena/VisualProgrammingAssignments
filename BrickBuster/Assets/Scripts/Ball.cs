using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float ballStartVelocity = 300f;
    private Rigidbody rb;
    private bool ballInPlay;

    private void Awake()
    {

        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {

        if (Input.GetButtonDown("Fire1") && ballInPlay == false) {

            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballStartVelocity, ballStartVelocity, 0));

        }

    }

}
