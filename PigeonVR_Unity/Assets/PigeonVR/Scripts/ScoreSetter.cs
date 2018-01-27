using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSetter : MonoBehaviour {

   private Text scoreText;

   [SerializeField]
   private Image life1;

   [SerializeField]
   private Image life2;

   [SerializeField]
   private Image life3;

   void OnEnable()
   {
      StateManager.Instance.onStateUpdate += changeScoreNLives;
   }

   void OnDisable()
   {
      StateManager.Instance.onStateUpdate -= changeScoreNLives;
   }

	// Use this for initialization
	void Start () {
      life1.gameObject.SetActive(true);
      life2.gameObject.SetActive(true);
      life3.gameObject.SetActive(true);

      scoreText = gameObject.GetComponent<Text>();
      scoreText.text = "Score: 0";
	}
	
   private void changeScoreNLives(int score, int lives)
   {
      scoreText.text = "Score: " + score;

      switch(lives)
      {
         case 2:
            life3.gameObject.SetActive(false);
            break;
         case 1:
            life2.gameObject.SetActive(false);
            break;
         case 0:
            life1.gameObject.SetActive(false);
            break;
         default: // lives = 3, do nothing
            break;
      }
   }
}
