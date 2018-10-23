/*

a. Diego Avena
b. 2299333
c. avena@chapman.edu
d. CPSC 236-02
e. FirstProject

*/

/*

This file is responsible for creating a text file and to input the following information inside of it:
-A start up message with a startup timestamp. 
-An end message that appears when the application closes, along with a timestamp of when the application closed.

*/

using UnityEngine;

/*

-Using System.IO is used to access writer in order to create and edit a .txt file.
-Using UnityEditor is used for accessing database so that we can use the import method to import the text file we create into the location we choose for it to be saved

*/
using System.IO;
using UnityEditor;

public class DataLogger : MonoBehaviour {

    /*

        -fileName: Stores the name of the file we will be editing
        -path: Stores the location where we will save the .txt file
        -filePath: Will store both the fileName and path to b allow us to save the file at the location specified by path.

    */
    private string fileName = "testLog";
    private string path = "Assets/Logs/";
    private string filePath;

    /*

        a. Method Name: Start();
        b. Return Value: n/a.
        c. Parameters: n/a
        d. Exceptions: n/a

    */
    private void Start()
    {

        /*Adds a startup message right when the program runs*/
        WriteString("Starting up...");

    }

    /*
        a. Method Name: WriteString("");
        b. Return Value: n/a
        c. Parameter: takes a parameter of type string called message, used to allow the input of a customized message into the .txt file
        d. Exceptions: n/a

        -WriteString is the method that creates a .txt file called testLog at the selected filePath if it does not exist, and allows for the editing of the text inside it.
            -Write String also adds the timestamps into the .txt file.

    */
    public void WriteString(string message) {

        /*Establishes the file path, or where to save the written file/testLog*/
        filePath = path + fileName + ".txt";

        /*
            -Creates the testLog file if it does not exist, or if it does exists, simply appends new text into it. 
            -writer.Close() saves the stuff written to the file
            
        */
        StreamWriter writer = new StreamWriter(filePath, true);
        writer.WriteLine("Timestamp: "+System.DateTime.Now);
        writer.WriteLine(message);
        writer.WriteLine("/////////////////////////////");
        writer.Close(); 

        /*
            -AssetDatabase.ImportAsset(filePath) places the testLog.txt file at the chosen directory. 
        */
        AssetDatabase.ImportAsset(filePath);

        /*
            -Resources.load reloads the testLog.txt file in order to allow for updates during runtime.
        */
        Resources.Load(filePath);

    }

    /*

        a. Method Name: OnApplicationQuit();
        b. ReturnValue: n/a
        c. Parameters: n/a
        d. Exceptions: n/a
        
        -I discovered this method existed from here: https://stackoverflow.com/questions/41503548/save-game-when-exiting-app
        -this method is called right before the application is about to close, used to write a closing message to the testLog.txt file and timestamp it with the shutdown time.

    */
    private void OnApplicationQuit()
    {

        WriteString("Shutting down...");

    }

}
