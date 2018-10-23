using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour {

    /*
      a. ExitGame()
      b. n/a
      c. n/a
      d. n/a
      
      -responsible for shutting the game down when the user clicks on the exit button. 
      -used only by the exit button in the mainMenu scene to avoid null reference errors

    */
    public void Exit()
    {
        //the if statement below allows for the checking of whether or not the editor is on or if the game is on a device, and shuts it off accordingly
        {
            #if UNITY_EDITOR

                UnityEditor.EditorApplication.isPlaying = false;

            #else

                Application.Quit();

            #endif

        }
    }

}
