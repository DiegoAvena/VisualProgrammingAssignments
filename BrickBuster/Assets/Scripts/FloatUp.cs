using UnityEngine;

public class FloatUp : MonoBehaviour {

    public float speed = 10;
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.Translate(0, speed, 0); //transform.Translate() moves the GameObject along the transform. Putting it inside of Update() keeps it consistently moving.

    }
}
