using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public KeyCode moveUp;
    public KeyCode moveDown;

    public float speed = 10;

    private Rigidbody2D rb2d;

    private void Start()
    {

        this.intializeGame();

    }

    private void intializeGame() {

        rb2d = GetComponent<Rigidbody2D>();

    }

    private void ResetPosition() {

        transform.position = new Vector2(transform.position.x, 0);

    }

    void Update () {
		
        if (Input.GetKey(moveUp) == true) { //shortcut for comparing the button the user pressed to the one we want them to press

            //Debug.Log("Up");
            rb2d.velocity = new Vector2(0, speed);
            
        }
        else if (Input.GetKey(moveDown) == true) {

            //Debug.Log("down");
            rb2d.velocity = new Vector2(0, -speed);

        }
        else {

            //Debug.Log("Stop");
            rb2d.velocity = new Vector2(0, 0);

        }

	}
}
