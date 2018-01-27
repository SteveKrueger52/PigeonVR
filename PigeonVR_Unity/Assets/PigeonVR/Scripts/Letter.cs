using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Letter : MonoBehaviour
{

    [SerializeField]
	Info.Location locationID;
    //String text of where the letter needs to go
    [SerializeField]
    string displayDestination;
    Text displayText;

    // Use this for initialization
    void Start()
    {
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
