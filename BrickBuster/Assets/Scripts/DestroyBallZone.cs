using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBallZone : MonoBehaviour {

    private GameManager gm;

    //This function will run before the Start function is run. Here we will use it to set our reference to the “GameManager” script.
    private void Awake()
    {

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    private void OnTriggerEnter(Collider other)
    {

        gm.LoseLife();
        Destroy(other.gameObject);

    }

}
