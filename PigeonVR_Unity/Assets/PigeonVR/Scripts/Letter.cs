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

    // Use this for initialization
    void Start()
    {
        letterID = Info.getRandomLocation();

        Canvas canvas = this.gameObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        GameObject go = new GameObject("LetterText");
        go.transform.SetParent(canvas.transform);
        displayText = go.AddComponent<Text>();

        Font morris = Resources.Load<Font>("MorrisRoman-Black");
        displayText.font = morris;

        displayText.transform.localScale = new Vector3(0.05f, 0.05f, 1);
        displayText.transform.localPosition = new Vector3(0, 0, 0);
        displayText.alignment = TextAnchor.UpperCenter;
        setStartData(letterID);
    }

    void setStartData(Info.Location id)
    {
        this.displayDestination = Info.getRandomSender(id);
        displayText.text = displayDestination;
    }
}
