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
        while (true) {
            int spawnloc = (int)Random.Range(0, spawnpoints.Length - 1);

            int letterToSpawn = (int)Random.Range(0, LetterTypes.Length - 1);

            Instantiate(LetterTypes[letterToSpawn]);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
