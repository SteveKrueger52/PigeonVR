using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBox : MonoBehaviour {

    private void OnTriggerExit(Collider collision)
    {
        
        var collided = collision.gameObject;
   

        if (collided.tag == "Pigeon")
        {
            var pigeon = collided.GetComponent<Pigeon>();
            pigeon.StartCoroutine("GuessIllDie");
            pigeon.FlightAway();
        }
    }
}
