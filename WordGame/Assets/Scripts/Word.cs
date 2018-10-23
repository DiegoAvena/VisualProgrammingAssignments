/*

a. Diego Avena, Jin Jung, Chase Toyofuku-Souza
b. 2299333, 2329401, 2296478
c. avena @chapman.edu, jijung @chapman.edu, toyofukusouza @chapman.edu
d. CS231-01
e. 03

*/

//Word: contains the string variables that each word prefab we put in the wordList will need to have

using UnityEngine;

public class Word : MonoBehaviour {

    public string word;//Word to be guessed by the user
    public string category;//Category hint for the user
    public string wordHint;//A hint for the user that is to be shown when they ask for it

    /*
      a. GetWordHint()
      b. wordHint, type string
      c. n/a
      d. n/a
      
      responsible for returning the hint string associated with each word prefab in the wordList

    */
    public string GetWordHint() {

        return wordHint;

    }


}
