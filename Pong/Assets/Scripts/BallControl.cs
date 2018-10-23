using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    private Rigidbody2D rgbd;

    public Rigidbody2D playerRigidBody;

    public float ballSpeed = 100;

    private AudioSource audioSourceOne;

	// Use this for initialization
	void Start () {

        rgbd = GetComponent<Rigidbody2D>();
        audioSourceOne = GetComponent<AudioSource>();
        Invoke("GoBall", 2);

    }

    private void Update()
    {

        if (rgbd.velocity.x < 18 && rgbd.velocity.x > -18 && rgbd.velocity.x != 0) {

            if (rgbd.velocity.x > 0) {

                rgbd.velocity = new Vector2(20, rgbd.velocity.y);

            }
            else {

                rgbd.velocity = new Vector2(-20, rgbd.velocity.y);

            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player") == true || collision.gameObject.CompareTag("playerTwo") == true) {

            rgbd.velocity = new Vector2(rgbd.velocity.x, (rgbd.velocity.y / 2) + (playerRigidBody.velocity.y / 3));
            audioSourceOne.pitch = Random.Range(0.8f, 1.2f);
            audioSourceOne.Play();

        }

    }

    private void ResetBall() {

        transform.position = new Vector2(0, 0);
        rgbd.velocity = new Vector2(0, 0);

        Invoke("GoBall", 1f);

    }

    private void GoBall() {

        float randomNumber = Random.Range(0, 2); //0...1

        if (randomNumber <= 0.5)
        {

            rgbd.AddForce(new Vector2(ballSpeed, 10));

        }
        else
        {

            rgbd.AddForce(new Vector2(-ballSpeed, -10));

        }


    }

}
