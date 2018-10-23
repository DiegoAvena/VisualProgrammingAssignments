using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialFlash : MonoBehaviour {

    public float resetDelay = 1f; //this will control how long until the material is reset to it’s original value.
    private Renderer rend; //This will hold the reference to our GameObject’s renderer component. We need access to this to update the material and color
    private Color originalColor; //This will hold the original color our material started with

    // Use this for initialization
    void Start () {

        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;

	}

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ball") == true) {

            rend.material.color = Color.red;
            Invoke("ResetMaterial", resetDelay); //We  use the Invoke function to call a function by stringName and set it delay as a float

        }

    }

    private void ResetMaterial() {

        rend.material.color = originalColor; //Here we reset our material back to our originalColor we stored when our object’s Start() function ran.

    }
}
