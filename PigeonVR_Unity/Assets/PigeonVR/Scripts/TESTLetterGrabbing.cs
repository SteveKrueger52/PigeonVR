using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TESTLetterGrabbing : MonoBehaviour {

    Text display;

	// Use this for initialization
	void Start () {
        display = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space))
        {
            display.text = Info.getRandomSender(Info.Location.DESERT);
        }
	}
}
