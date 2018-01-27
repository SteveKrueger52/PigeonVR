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

	// Use this for initialization
	void Start () {
		cooTimer = Random.Range (0f, cooInterval);
		if (emptyBirb.gameObject.activeInHierarchy && fullBirb.gameObject.activeInHierarchy)
			fullBirb.gameObject.SetActive (false);
	}

	void setBirbStatus (bool laden) {
		_laden = laden;
		emptyBirb.SetActive (!laden);
		fullBirb.SetActive (laden);
	}

	// Update is called once per frame
	void Update () {
		cooTimer -= Time.deltaTime;
		if (cooTimer < 0f) {
			source.PlayOneShot (cooSound);
			cooTimer = Random.Range (0f, cooInterval);
		}
	}

	public void attachLetter(Letter letter) {
		if (!_laden) {
			letter.transform.SetParent (gameObject.transform);
			letterLocation = letter.getLocation ();
			setBirbStatus (true);
			letter.gameObject.SetActive (false);
			source.PlayOneShot (attachObjectSound);
		} else {
			Debug.Log ("Birb is carrying too much!");
		}
	}

	public Letter detachLetter() {
		if (_laden) {
			Letter letter = GetComponentInChildren<Letter> ();
			letter.gameObject.SetActive (true);
			letter.transform.SetParent (StateManager.instance.birbCoop);
			setBirbStatus (false);
			source.PlayOneShot (attachObjectSound);
			return letter;
		} else {
			Debug.Log ("Birb has no Mail");
			return null;
		}
	}
}
