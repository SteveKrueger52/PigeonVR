using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public class Pigeon : VRTK_InteractableObject {
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

	// Use this for initialization
	void Awake () {
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

	// onTriggerExit of the Cylindrical Collider
	public bool birbHitCorrectTarget() {
			return false;
	}

}
