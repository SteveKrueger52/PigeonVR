using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
      {
         Debug.Log("lose a life");
         StateManager.Instance.updateAfterThrow(false);
      }
      else if (Input.GetKeyDown(KeyCode.UpArrow))
      {
         StateManager.Instance.updateAfterThrow(true);
      }
	}
}
