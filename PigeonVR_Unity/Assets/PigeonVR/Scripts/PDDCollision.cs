using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDDCollision : MonoBehaviour {

    [SerializeField]
    Info.Location location;

    private void OnCollisionExit(Collision collision)
    {
        var collided = collision.gameObject;

        if (collided.tag == "Pigeon")
        {
            var pigeon = collided.GetComponent<Pigeon>();
            //CHECKS FOR correct letter
            if (pigeon._laden)
            {
                StateManager.Instance.updateAfterThrow(pigeon.letterLocation == this.location);
            }

            pigeon.StartCoroutine("GuessIllDie");
        }
    }
}
