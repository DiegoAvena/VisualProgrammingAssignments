/*

a. Student Name: Diego Avena
b. Student ID: 2299333
c. Student Email: avena@chapman.edu
d. Course: CPSC 236-02
e. Assignment: FirstProject, assignment number 1

*/

/*

This file is responsible for keeping track of when the user presses the UI button and the spacebar, and for logging these occurances into
the testLog.txt file.

*/
using UnityEngine;

public class Test : MonoBehaviour {

    /* dataLoggerReference is used to link this class to the DataLogger.cs class so that Test.cs can use the WriteString method.*/
    private DataLogger dataLoggerReference;

    /*
        a. Method Name: Start();
        b. Return Value: n/a
        c. Parameters: n/a
        d. Exceptions: n/a

    */
    private void Start()
    {

        /*Finds the gameobject with this tag and assigns the DataLogger Script component of this game object to our dataLoggerReerence variable*/
        dataLoggerReference = GameObject.FindGameObjectWithTag("DataLogger").GetComponent<DataLogger>();

    }

    /*

        a.) Method Name: Update();
        b.) Return Value: n/a
        c.) Parameters: n/a
        d.) Exceptions: n/a

    */
    private void Update()
    {

        /*

            -If statement below is checked every frame and is used to keep track of when the user presses the spacebar button down, and logs the occurance of this into testLog.txt using
               the WriteString() method.

        */
        if (Input.GetKeyDown(KeyCode.Space)) {

            dataLoggerReference.WriteString("Spacebar was pressed");

        }
        
    }


    /*

        a. Method Name: ButtonPressed();
        b. Return Value: n/a
        c. Parameters:n/a
        d. Exception: n/a

        -ButtonPressed("") is called by the UI Button when the user clicks it, and logs the occurance of this click on the testLog.txt file.

    */
    public void ButtonPressed(string buttonMessage) {

        dataLoggerReference.WriteString(buttonMessage + " button was pressed.");

    }

}
