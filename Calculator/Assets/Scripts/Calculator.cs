/*

Name: Diego Avena
Student ID#: 2299333
Chapman email: avena@chapman.edu
Course Number and Section: CPSC 236-02
Assignment: Calculator

*/

using UnityEngine;

/*

-using UnityEngine.UI is needed to get access to the Text component of the calculator that will display the calulations and answer.

*/

using UnityEngine.UI;

/*

-Calculator.cs adds in basic calculator functions into the calculator created in the Unity Editor.

*/
public class Calculator : MonoBehaviour {

    /*

    -operation will store the operation the user wants to use so that the program can determine which operation to perform later.
    -num1 will store the first number the user wants to use
    -num2 will store the second number the user wants to use
    -answer will store the result of the operation performed on num1 and num2
    -calculatorText references calulatorText so that the text component of this can be set as needed
    -userInputedADecimalAlready used to insure that the user cannot input multiple decimal points in
    -shouldShowDivideByZeroMessageInstead used to check if whether the divide by zero message should be shown or if the calculation's result should be shown inside calculatorText.text.

    */
    public string operation;
    public string num1 = null;
    public string num2 = null;
    public float answer;
    public Text calculatorText;

    private bool userInputedADecimalAlready = false;
    private bool shouldShowDivideByZeroMessageInstead = false;

    /*

    a. Start();
    b. n/a
    c. n/a
    d. n/a
    
    -Start() in this case is used to call Reset() so that the calulator is reset on launch.

    */
    private void Start()
    {

        Reset();

    }

    /*

    a. AddNumber();
    b. n/a
    c. thisNum, of type string, stores the number the user wants to use and sets either num1 or num2 to this value according to a set of conditions.
    d. n/a
    
    -AddNumber(String thisNum) sets the numbers the user wants to use to compute the answer

    */
    public void AddNumber(string thisNum) {

        /*  

        -The numbers the user inputs will be appended to the num1, with +=, string until the user inputs an operator, allowing for multidigit numbers like 712 to be made.
        -The numbers the user inputs will be appended to the num2, with +=, string until the user clicks on the equal sign, allowing for multidigit numbers like 712 to be made.

        */
        if (operation == null) {

            if (thisNum == ".") {

                /*

                -If statement below prevents the user from inserting multiple decimal pts for num1

                */
                if (userInputedADecimalAlready == false) {

                    num1 += thisNum;
                    userInputedADecimalAlready = true;

                }


            }
            else {

                num1 += thisNum;

            }

        }
        else {

            if (thisNum == ".") {

                /*

                -If statement below prevents the user from inserting multiple decimal pts for num1

                */
                if (userInputedADecimalAlready == false) {

                    num2 += thisNum;
                    userInputedADecimalAlready = true;

                }

            }
            else {

                num2 += thisNum;

            }

        }
        UpdateCalculatorDisplay();

    }

    /*

    a. SetOperation();
    b. n/a
    c. thisOp, of type string, stores the operation the user wants to use and sets the operation variable to this.
    d. n/a

    -SetOperation() sets the operation to use in order to compute the answer

    */
    public void SetOperation(string thisOp) {

        operation = thisOp;
        userInputedADecimalAlready = false;
        UpdateCalculatorDisplay();

    }

    /*

    a. Calculate();
    b. n/a
    c. n/a
    d. n/a
    
    -Calculate() takes num1 and num2 and performs the correct mathematical operation on them to get a result and store it in answer. Called when the user pressed =.

    */
    public void Calculate() {

        /*

        -float.Parse() referenced from: https://answers.unity.com/questions/11581/convert-string-to-float.html
        -float.Parse() is used to convert the string value of num1 and num2 into floats, so that mathematical operations can be performed on them.
        
        */
        if (num1 != "." && num2 != ".") {

            /*

            -The outer if statement is meant to prevent an error from occuring when the user inputs only a decimal point for num1 or num2

            */
            if (operation == "/")
            {

                /*

                -if statement below ensures that the system never attempts to divide by zero, and if the user is attempting this, the system will tell them that they cannot divide by zero.

                */
                if (float.Parse(num2).Equals(0))
                {

                    calculatorText.text = "Cannot divide by zero.";
                    shouldShowDivideByZeroMessageInstead = true;
                    return;

                }

                answer = float.Parse(num1) / float.Parse(num2);

            }
            else if (operation == "+")
            {

                answer = float.Parse(num1) + float.Parse(num2);

            }
            else if (operation == "-")
            {

                answer = float.Parse(num1) - float.Parse(num2);

            }
            else if (operation == "*")
            {

                answer = float.Parse(num1) * float.Parse(num2);

            }

            if (shouldShowDivideByZeroMessageInstead == false)
            {

                DisplayAnswer();

            }

        }
        else {

            /*

            -If Display answer is called in this section, then the calculator text will be set to tell the user "Invalid Syntax", meaning they inputed either num1 or num2 or both as only decimal points

            */
            DisplayAnswer();

        }

    }

    /*

    a. DisplayAnswer();
    b. n/a
    c. n/a
    d. n/a
    
    -DisplayAnswer() is used when the answer has been computed, and updates the calculator display text to include this answer in bold so the user can see the results
    -System.Math.round is cited from: https://answers.unity.com/questions/535424/round-float-with-2-decimal.html
    -System.Math.round is used to round the answer variable to 2 decimal places.

    */
    public void DisplayAnswer() {

        if (num1 == "." || num2 == ".")
        {

            calculatorText.text = "Invalid syntax";
            return;
        }
        else {

            answer = (float)System.Math.Round(answer, 2);
            calculatorText.fontStyle = FontStyle.Bold;
            calculatorText.fontSize = 24;
            calculatorText.text = num1 + " " + operation + " " + num2 + " = " + answer;

        }

    }


    /*

    a. Reset();
    b. n/a
    c. n/a
    d. n/a

    -Reset() is used to reset all the variables and the display text of the calculator when the user presses the clear button.
    
    */
    public void Reset()
    {

        shouldShowDivideByZeroMessageInstead = false;
        calculatorText.text = "0"; //zero out the display to the user
        calculatorText.fontStyle = FontStyle.Normal;
        calculatorText.fontSize = 14;
        operation = null;
        num1 = null;
        num2 = null;
        answer = 0;
        userInputedADecimalAlready = false;

    }

    /*

    a. UpdateCalculatorDisplay();
    b. n/a
    c. n/a
    d. n/a
    
    -UpdateCalculatorDisplay() is used to update the calculator display text when ever the user inputs a number or operator.

    */
    public void UpdateCalculatorDisplay() {

        calculatorText.text = num1 + " " + operation + " " + num2;

    }

    /*

    a. ShutOffCalculator();
    b. n/a
    c. n/a
    d. n/a

    -ShutOffCalculator() is responsible for shutting down the calculator when the user hits the off button. The #If statements are used to check 
        if the app is being used in the unity editor or on an actual device like the computer, and uses the appropriate means to shut off the program

    -The #if statements, along with the code used to shut off the application, is referenced from: https://answers.unity.com/questions/161858/startstop-playmode-from-editor-script.html

    */
    public void ShutOffCalculator() {

        Reset();

        #if UNITY_EDITOR 
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif

    }

}
