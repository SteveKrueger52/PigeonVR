using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterGenerator : MonoBehaviour {

    [SerializeField]
    GameObject[] spawnpoints;

    [SerializeField]
    float spawnDelay;

    [SerializeField]
    GameObject[] LetterTypes;


    // Use this for initialization
    void Start () {
        StartCoroutine("spawnLetters");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator spawnLetters()
    {

        yield return new WaitForSeconds(spawnDelay);
    }
}
