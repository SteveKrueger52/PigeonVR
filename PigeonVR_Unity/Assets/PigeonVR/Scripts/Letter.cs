using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Letter : MonoBehaviour
{

    [SerializeField]
    Info.Location letterID;
    //String text of where the letter needs to go
    [SerializeField]
    string displayDestination;
    Text displayText;
    [SerializeField]
    float decayTime;
    [SerializeField]
    Image decayUI;

   /*public IEnumerator Timer(float totalTime, int tickNum)
   {
      for (int i = 0; i < tickNum; i++)
      {
         DoUI(totalTime/(float)tickNum);

         yield return new WaitForSeconds(totalTime / tickNum);
      }

   }*/

    // Use this for initialization
    void Start()
    {
        letterID = Info.getRandomLocation();

        Canvas canvas = this.gameObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        GameObject go = new GameObject("LetterText");
        go.transform.SetParent(canvas.transform);
        displayText = go.AddComponent<Text>();

        Image decay = (Image)Instantiate(decayUI);
        decay.transform.SetParent(canvas.transform);
      decay.transform.localScale = new Vector3(0.01f, 0.01f, 1);
      decay.rectTransform.localPosition = new Vector3(0, -1, 0);

        Font morris = Resources.Load<Font>("MorrisRoman-Black");
        displayText.font = morris;

        displayText.transform.localScale = new Vector3(0.05f, 0.05f, 1);
        displayText.transform.localPosition = new Vector3(0, 0, 0);
        displayText.alignment = TextAnchor.UpperCenter;
        setStartData(letterID);

        // StartCoroutine("Timer");
    }

    void setStartData(Info.Location id)
    {
        this.displayDestination = Info.getRandomSender(id);
        displayText.text = displayDestination;
    }

   void DoUI(float amt) 
   {
      decayUI.fillAmount = amt;
   }
}
