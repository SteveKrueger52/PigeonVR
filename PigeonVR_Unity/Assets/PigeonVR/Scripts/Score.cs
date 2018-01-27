using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {

	private Text display;

	void Start()
	{
		display = GetComponent<Text>();
	}
	
	void Update () {
		display.text = "Score: " + GameManager.Score.ToString();
		if (Input.GetKeyUp(KeyCode.Space))
        {
            GameManager.updateScore(1);
        }
	}
}
