using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour {

    private AudioSource audioSource;

    private GameObject playerTwo;

    private void Start()
    {

        playerTwo = GameObject.FindWithTag("playerTwo");
        audioSource = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "Ball") {
        
            GameManager.Score(transform.name);
            playerTwo.gameObject.SendMessage("ResetPosition");
            collision.gameObject.SendMessage("ResetBall");
            audioSource.Play();

        }

    }

}
