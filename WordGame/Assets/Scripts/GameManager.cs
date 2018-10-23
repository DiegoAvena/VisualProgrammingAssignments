/*

a. Diego Avena, Jin Jung, Chase Toyofuku-Souza
b. 2299333, 2329401, 2296478
c. avena @chapman.edu, jijung @chapman.edu, toyofukusouza @chapman.edu
d. CS231-01
e. 03

*/

/*

GameManager: responsible for running the entire game properly. It also manages the transition from scene to scene.

*/

using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
    public List<Word> wordList;
    public List<string> usedLetterList;
    public string wordToGuess;
    public string guess;
    public string displayWord;
    public int guessesRemaining = 5;
    public double time = 0;

    public InputField mainInputField;
    public Text wordGuessGO;
    public Text categoryGO;
    public Text guessRemainingGO;
    public Text usedLettersGO;
    public Text endText;
    public Text timer;
    public Text hintText;
    public GameObject playAgainBtn;

    private int randomNumber;

    private string sceneName;

    //Add a bool to track when game is over
    private bool gameOver = false;

    private bool timedModeOn = false;

    public AudioSource BGM;

    /*
        a. Start()
        b. n/a
        c. n/a
        d. n/a

    */
    void Start()
    {

        sceneName = SceneManager.GetActiveScene().name;

        BGM.Play();

        if (sceneName == "wordGame") {

            //timed mode
            timedModeOn = true;
            BGM.pitch *= 4.5f;

        }

        //Set the word to guess
        SetWordToGuess();

        //Update the word display
        UpdateWordDisplay();

        //Automatically select the input for the user. 
        //This is so the user doesn't need to "click" on the input field every time they want to type a character.
        SelectInput();

        //do not want to show any of this yet until the game has ended
        endText.enabled = false;
        playAgainBtn.SetActive(false);

        //do not want to show this unless the user clicks the hint button
        hintText.enabled = false;

    }

    /*
        a. Update()
        b. n/a
        c. n/a
        d. n/a

    */
    void Update()
    {
        //if game is not over, run timer
        if(gameOver != true && timedModeOn == true)
        {
            time += Time.deltaTime;
    
            timer.text = "15 Second Mode! Time Elapsed: " + System.Math.Round(time).ToString() + " seconds";
        }
        CheckGameOver();

        //do not allow the user to keep inputing letters if the game has already ended. If the game is still going on, keep the input selected 
        //so that the user does not need to click on it all the time to activate it
        if (gameOver) {

            DeselectInput();

        }
        else {

            SelectInput();

        }

    }
    
    /*
        a. SetWordHint()
        b. n/a
        c. n/a
        d. n/a

        Responsible for grabbing the hint from the word chosen and displaying it to the user when they click the hint btn.

    */
    public void SetWordHint() {

        hintText.text = wordList[randomNumber].wordHint;
        hintText.enabled = true;

        SelectInput();

    }

    /*
        a. SetWordGuess()
        b. n/a
        c. n/a
        d. n/a

        Responsible for choosing a random word from wordList for user to guess.

    */
    void SetWordToGuess() {

        //Pick a random number between zero and the amount of words in "wordList"
        randomNumber = Random.Range(0, wordList.Count);

        //set the wordToGuess
        wordToGuess = wordList[randomNumber].word;

        displayWord = wordToGuess;
        //Clear out the word to guess and make it only asterisks
        ReplaceAllLetters(displayWord, '*');

        categoryGO.text = wordList[randomNumber].category;
    }

    /*
        a. LetterCheck(string letterGuessed)
        b. n/a
        c. letterGuessed, type string
        d. n/a

        responsible for decrementing the letters remaining based on the users guess and for managing the lives of the user based on whether or not their 
        guess is correct

    */
    public void LetterCheck(string letterGuessed) {

        guess = letterGuessed;

        guess = guess.ToLower();

        //Use regex to replace any invalid entry with an empty string
        guess = Regex.Replace(guess, @"[^a-z]", string.Empty);

        if (!usedLetterList.Contains(guess) && !gameOver)
        {
            usedLetterList.Add(guess);

            //Check to see if our "word to guess" contrains the players guess
            if (wordToGuess.Contains(guess))
            {
                UpdateLetters();
            }
            else
            {
                //The letter is not part of the word, so remove a "guess from the counter
                guessesRemaining--;

                //Update the "guesses remaining" UI
                guessRemainingGO.text = "Guesses Remaining : " + guessesRemaining.ToString();

            }

            //Check for game over
            CheckGameOver();

            //Update the letter display to show the used letters
            ShowUsedLetters();

        }

        SelectInput();

    }

    /*
        a. ShowUsedLetters()
        b. n/a
        c. n/a
        d. n/a

        responsible for updating the text on the usedLetterGO text object to show which letters the user has guesses/used already

    */
    private void ShowUsedLetters() {

        usedLettersGO.text += guess;

    }

    /*
      a. SelectInput()
      b. n/a
      c. n/a
      d. n/a
      
      responsible for automatically selecting the input box so that the user does not need to click on it for it to be activated. 

    */
    void SelectInput()
    {
        if (!gameOver)
        {
            //Reset input to nothing
            mainInputField.text = ""; 

            //Activate the main input field
            mainInputField.ActivateInputField();

        }

    }

    /*
      a. DeselectInput()
      b. n/a
      c. n/a
      d. n/a
      
      responsible for automatically deselecting the input box, used when the game ends so the user cannot enter anymore text unless they click on the input box 

    */
    private void DeselectInput() {

        mainInputField.text = "";
        mainInputField.DeactivateInputField();

    }

    /*
      a. ExitGame()
      b. n/a
      c. n/a
      d. n/a
      
      responsible for shutting the game down when the user clicks on the exit button. 

    */
    public void ExitGame()
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

    /*
      a. UpdateLetters()
      b. n/a
      c. n/a
      d. n/a
      
      responsible for updating the displayword variable with the letter the user inputed if it is correct 

    */
    void UpdateLetters() {
        int charIndex = 0;

        for (int i = 0; i < wordToGuess.Length; i++) {
            //Convert to a string to compare
            if (wordToGuess[i].ToString() == guess) {

                charIndex = i;
                //Remove placeholder character
                displayWord = displayWord.Remove(charIndex, 1);

                displayWord = displayWord.Insert(charIndex, guess);
            }
        }
        UpdateWordDisplay();
    }

    /*
      a. UpdateWordDisplay()
      b. n/a
      c. n/a
      d. n/a
      
      responsible for updating the wordGuess game object to contain the letter the user guessed, allowing them to visually see the word they are guessing 

    */
    void UpdateWordDisplay()
    {

        wordGuessGO.text = displayWord;

        //Check to see if player has guess all letters
        CheckGameOver();

    }

    /*
      a. ReplaceAllLetters()
      b. n/a
      c. n/a
      d. n/a
      
      responsible for determining the lenth of the word the user will need to guess, and displaying this length to the user
      visually through the use of * characters.

    */
    void ReplaceAllLetters(string input, char target) {

        //determine how long the word to guess is
        StringBuilder sb = new StringBuilder(input.Length);

        //Iterate through the characetrs in the string builder we created above
        //Using the length of the original word, add in placeholder chars
        for(int i = 0; i < wordToGuess.Length; i++)
        {
            sb.Append(target);
        }

        //Update the display word to be the string we built above
        displayWord = sb.ToString();
    }

    /*
      a. CheckGameOver()
      b. n/a
      c. n/a
      d. n/a
      
      responsible for checking if the game is over and displaying whther the user won or loss and enabling the playAgain button

    */
    private void CheckGameOver()
    {

        //determine how the game should end and what the end message should be
        if (displayWord == wordToGuess)
        {

            endText.text = "You Win!";
            gameOver = true;

        }
        else if (guessesRemaining <= 0)
        {
            endText.text = "Game Over. Out of guesses!";
            gameOver = true;

        }
        else if (time >= 15 && timedModeOn == true)
        {
            endText.text = "Game Over. Out of Time!";
            gameOver = true;
        }

        //show the gameover options, like the playAgainBtn
        if (gameOver) {

            ShowUsedLetters();
            endText.enabled = true;
            playAgainBtn.SetActive(true);
            DeselectInput();

        }

    }

}
