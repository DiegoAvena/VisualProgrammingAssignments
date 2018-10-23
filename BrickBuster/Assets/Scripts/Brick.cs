using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public GameObject brickDestroyParticle;

    private GameManager gm;

    private void Awake()
    {

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    private void OnCollisionEnter(Collision collision)
    {

        Instantiate(brickDestroyParticle, transform.position, Quaternion.identity);
        gm.IncreaseScore();
        Destroy(gameObject);

    }

}
