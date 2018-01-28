using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Letter : MonoBehaviour
{
    private GameObject[] models;
    private Info.Location locationID;
    private string displayDestination;
    private Text displayText;

    private Pigeon birbTouched;

    public float decayTime;


    // Use this for initialization
    void Awake()
    {
        models = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            models[i] = transform.GetChild(i).gameObject;
            models[i].SetActive(false);
        }
        models[Random.Range(0, models.Length - 1)].SetActive(true);

		GetComponent<Rigidbody> ().velocity = new Vector3();

        displayText = GetComponentInChildren<Text>();
        locationID = Info.getRandomLocation();

        Canvas canvas = this.gameObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        GameObject go = new GameObject("LetterText");
        go.transform.SetParent(canvas.transform);
        displayText = go.AddComponent<Text>();

        Font morris = Resources.Load<Font>("MorrisRoman-Black");
        displayText.font = morris;

        displayText.transform.localScale = new Vector3(0.01f, 0.01f, 1);
        displayText.transform.localPosition = new Vector3(0, 0, 0);
        displayText.fontSize = 20;
        displayText.alignment = TextAnchor.UpperCenter;
        setStartData(locationID);
        StartCoroutine("Timer");
    }

    void setStartData(Info.Location id)
    {
        this.displayDestination = Info.getRandomSender(id);
        displayText.text = displayDestination;
    }

    void OnCollisionEnter(Collision col)
    {
        birbTouched = col.gameObject.GetComponent<Pigeon>();
        if (birbTouched != null)
            birbTouched.addLetter(this);
    }

    public IEnumerator Timer()
   {
       yield return new WaitForSeconds(decayTime);
       Destroy(this.gameObject);
   }

    public Info.Location getLocation()
    {
        return locationID;
    }
}
