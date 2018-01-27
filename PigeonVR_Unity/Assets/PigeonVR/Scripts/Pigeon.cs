using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pigeon : MonoBehaviour {
	[SerializeField] private MeshRenderer emptyBirb;
	[SerializeField] private MeshRenderer fullBirb;

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

	void setBirbStatus (bool laden) {
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
}
