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

    // Use this for initialization
    void Start()
    {
		models = new GameObject[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			models [i] = transform.GetChild (i).gameObject;
			models [i].SetActive (false);
		}
		models [Random.Range (0, models.Length - 1)].SetActive (true);
        displayText = GetComponentInChildren<Text>();
        locationID = Info.getRandomLocation();
        setStartData(locationID);
    }

    void setStartData(Info.Location id)
    {
        this.displayDestination = Info.getRandomSender(id);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Start();
            displayText.text = displayDestination;
            Debug.Log(locationID);

        }
    }

	public Info.Location getLocation() {
		return locationID;
	}
}
