/*

a. Diego Avena, Jin Jung, Chase Toyofuku-Souza
b. 2299333, 2329401, 2296478
c. avena @chapman.edu, jijung @chapman.edu, toyofukusouza @chapman.edu
d. CS231-01
e. 03

*/

//LoadScene: responsible for loading new scenes using LoadLevel

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
   
    /*
      a. LoadLevel(string sceneName)
      b. n/a
      c. sceneName, type string
      d. n/a
      
      responsible for transitioning from one scene to the other based on sceneName

    */
    public void LoadLevel(string sceneName) {

        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);

    } 
}
