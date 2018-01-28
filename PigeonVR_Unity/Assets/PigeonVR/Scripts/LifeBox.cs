using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionExit(Collision collision)
    {
        var collided = collision.gameObject;

        var pigeon = collided.GetComponent<Pigeon>();   
        if (collided.tag == "Pigeon")
        {
            pigeon.StartCoroutine("GuessIllDie");
        }
    }
}
