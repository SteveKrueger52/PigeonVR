using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pigeon : MonoBehaviour {
	[SerializeField] private GameObject emptyBirb;
	[SerializeField] private GameObject fullBirb;

	private bool _laden = false;
	private Info.Location letterLocation;

	[SerializeField] private AudioSource source;
	[SerializeField] private AudioClip cooSound;
	[SerializeField] private AudioClip attachObjectSound;
	[SerializeField] private AudioClip grabSound;
	[SerializeField] private AudioClip throwSound;

	[SerializeField] private float cooInterval= 5f;
	private float cooTimer;


	// attach letters
	// detach letters

	// Use this for initialization
	void Start () {
		cooTimer = Random.Range (0f, cooInterval);
		if (emptyBirb.gameObject.activeInHierarchy && fullBirb.gameObject.activeInHierarchy)
			fullBirb.gameObject.SetActive (false);
	}

	void setBirbLaden (bool laden) {
		_laden = laden;
		emptyBirb.gameObject.SetActive (!laden);
		fullBirb.gameObject.SetActive (laden);
	}

	// Update is called once per frame
	void Update () {
		cooTimer -= Time.deltaTime;
		if (cooTimer < 0f) {
			source.PlayOneShot (cooSound);
			cooTimer = Random.Range (0f, cooInterval);
		}
	}

	public void setLocation(Info.Location loc) {
		letterLocation = loc;
	}

	public void addLetter(Letter l) {
		if (_laden) {
			Debug.Log ("Birb is carrying too much");
		} else {
			letterLocation = (Info.Location) l.getLocation ();
			l.transform.SetParent (gameObject.transform);
			setBirbLaden (true);
			l.gameObject.SetActive (false);
			source.PlayOneShot (attachObjectSound);
		}
	}

	public Letter takeLetter() {
		if (!_laden) {
			Debug.Log ("Birb doesn't have any items");
			return null;
		} else {
			Letter l = gameObject.GetComponentInChildren<Letter> ();
			l.transform.SetParent (StateManager.instance.transform);
			setBirbLaden (false);
			l.gameObject.SetActive (true);
			source.PlayOneShot (attachObjectSound);
			return l;
		}
	}




	// onTriggerExit of the Cylindrical Collider
	public bool birbHitCorrectTarget() {
		return false; //TODO
	}

}
