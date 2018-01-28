using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public class Pigeon : VRTK_InteractableObject {
	[SerializeField] private GameObject emptyBirb;
	[SerializeField] private GameObject fullBirb;
	[SerializeField] private float despawnTime = 2f;
	private bool inSweetSpot = true;

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

	void OnCollisionExit(Collision col) {
		if (col.gameObject.CompareTag ("SweetSpot")) {
			inSweetSpot = false;
			return;
		}
		if (col.gameObject.CompareTag ("Killplane")) {
			StartCoroutine ("GuessIllDie");
			StateManager.instance.updateAfterThrow (birbHitCorrectTarget ());
		}
	}

	private void GuessIllDie() {
		yield return new WaitForSeconds (despawnTime);
		Destroy (this);
	}

	// onTriggerExit of the Cylindrical Collider
	public bool birbHitCorrectTarget() {
		if (!inSweetSpot || !_laden)
			return false;
		float wedge = 51.428f; //degrees
		int wedgeIndex = 3;
		// ANGULAR MATH HERE
		Vector3 birbPos = transform.position;
		Vector2 flatVector = new Vector2 (birbPos.x, birbPos.z).normalized;
		if (flatVector.x != 0f) {
			float angleFromForward = 
				// Sin is Vertical over Hypotenuse
				// Hypotenuse is 			sqrt 			(vertical ^2) 		   + 			(horiz^2)
				Mathf.Asin(flatVector.x/(Mathf.Sqrt ((flatVector.x * flatVector.x) + (flatVector.y * flatVector.y))));
			bool negative = (angleFromForward < 0f);
			angleFromForward = Mathf.Abs (Mathf.Rad2Deg * angleFromForward) + (wedge / 2);
			int offset = (int) Mathf.Floor (angleFromForward / wedge);
			wedgeIndex = negative ? wedgeIndex - offset : wedgeIndex + offset;

			// FINAL CHECK
			return letterLocation.Equals((Info.Location) wedgeIndex);

			/* THE WAY THIS WORKS IN TERMS OF PLACEMENT: 
			 * LOCATION 3 (SNOW) IS DIRECTLY FORWARD
			 * LOCATION INDICES COUNT DOWN TO THE RIGHT (2: DESERT, 1: FOREST, 0: TOWN)
			 * LOCATION INDICES COUNT UP TO THE LEFT (4: VOLCANO, 5: WASTELAND, 6: CITY)
			 */
	}
}
