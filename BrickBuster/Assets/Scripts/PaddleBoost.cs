using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*

when the player hits spacebar they will activate a “boost” on their paddle. While the boost is active, if the ball collides with the paddle it will get a boost to it’s velocity, display text to the player, and update the Score UI text style,color, and size.

*/
public class PaddleBoost : MonoBehaviour {

    bool boost = false; // a bool we can set to true while the boost is active.
    public float paddleBoost = 1f; //Setting the force which will be applied to the ball on collision.
    private Renderer rend; //We set a private variable to be used when updating the color of the paddle.
    public GameObject boostNotification; //the prefab we will instantiate that floats up and displays our bonus text.
    private GameManager gm; //private reference to the GameManager script.
    public float multiplierDuration = 5f; //The duration of how long the multiplier will last.

    // Use this for initialization
    void Start () {

        rend = GetComponent<Renderer>();
        rend.material.color = Color.cyan;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Space) && boost == false) {

            boost = true;
            Invoke("ResetBoost", 1f);
            rend.material.color = Color.green;

        }

	}

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ball") == true) {

            if (boost == true) {

                collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(paddleBoost, paddleBoost, 0));
                Instantiate(boostNotification, this.gameObject.transform.position, Quaternion.identity); //Instantiate the “BoostNotification” GameObject at the paddle’s transform.position. This allows the text to appear right above the paddle when the function is triggered.
                gm.MultiplierActivate(multiplierDuration);

            }

        }

    }

    private void ResetBoost() {

        boost = false;
        rend.material.color = Color.cyan;

    }

    /*private void Instantiate(GameObject boostNotification, PaddleBoost paddleBoost, Vector3 position, Quaternion identity)
    {
        throw new NotImplementedException();
    }*/
}
