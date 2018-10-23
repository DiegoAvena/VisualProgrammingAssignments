using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static int playerOneScore = 0;
    public static int playerTwoScore = 0;

    public GUISkin theSkin;

    private GameObject theBall;
    private GameObject playerOne;
    private GameObject playerTwo;

    private void Start()
    {

        theBall = GameObject.FindWithTag("ball");

        playerOne = GameObject.FindWithTag("Player");

        playerTwo = GameObject.FindWithTag("playerTwo");

    }

    public static void Score(string wallName) {

        if (wallName == "rightWall") {

            playerOneScore++;

        }
        else if (wallName == "leftWall") {

            playerTwoScore++;

        }

    }

    private void OnGUI()
    {

        GUI.skin = theSkin;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 18, 20, 100, 100), "" + playerOneScore);
        GUI.Label(new Rect(Screen.width / 2 + 150 - 18, 20, 100, 100), "" + playerTwoScore);

        if (GUI.Button(new Rect((Screen.width / 2) - (121 / 2), 20, 121, 53), "RESET")) { //anchor pts for GUI stuff are on the top left corner!

            playerOneScore = 0;
            playerTwoScore = 0;

            playerOne.SendMessage("ResetPosition");
            playerTwo.SendMessage("ResetPosition");

            theBall.SendMessage("ResetBall");

        }

    }

}
