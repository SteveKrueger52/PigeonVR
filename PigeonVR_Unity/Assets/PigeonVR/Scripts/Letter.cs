using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Letter : MonoBehaviour
{
	private GameObject[] modelTypes;
	private int modelIndex = -1;
	private GameObject activeModel;
    private Info.Location letterID;
    //String text of where the letter needs to go
    [SerializeField]
    string displayDestination;
    Text displayText;

	void Awake() {
		Init ();
	}

    // Use this for initialization
    void Init()
    {
		Collider[] colliders = GetComponentsInChildren<Collider> ();
		modelTypes = new GameObject[colliders.Length];
		for (int i = 0; i < colliders.Length; i++)
			modelTypes [i] = colliders [i].gameObject;
		if (modelIndex < 0 || modelIndex > modelTypes.Length) {
			foreach (GameObject go in modelTypes)
				go.SetActive (false);
			activeModel = modelTypes [Random.Range (0, modelTypes.Length)];
			activeModel.SetActive (true);
		}

		displayText = GetComponentInChildren<Text>();
		letterID = (Info.Location) Random.Range (0, 6);
		setStartData(letterID);
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
			Init ();
            displayText.text = displayDestination;
            Debug.Log(letterID);

        }
    }

	public Info.Location getLocation() {
		return letterID;
	}
}
