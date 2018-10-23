/*

 a. Full Name: Diego Avena
 b. Student id: 2299933
 c. Email: avena@chapman.edu
 d. Course: 236-02
 e. Project Name: VSDemo
 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public string customText;

    private int spaceBarPresses;

    //how do you get a timestamp right when unity starts and ends!

	// Use this for initialization

	void Start () {

        Debug.Log("Hello World " + customText);

	}


    // Update is called once per frame
    void Update () {
		
        if (Input.GetKeyDown(KeyCode.Space) == true) {

            spaceBarPresses++;
            Debug.Log("Total space bar presses: "+spaceBarPresses);
            Debug.Log("Timestamp: " + System.DateTime.Now);

        }


	}

    

}
