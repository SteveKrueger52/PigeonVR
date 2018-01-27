using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSetter : MonoBehaviour {
   private int score = 0;

   // [SerializeField]
   private Text scoreText;

	// Use this for initialization
	void Start () {
      scoreText = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
      scoreText.text = "Score: " + score;
	}
}
