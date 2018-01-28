using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    [SerializeField]
    GameObject[] spawnpoints;

    private float spawnDelay;

    [SerializeField]
    GameObject[] ObjectsToSpawn;


    // Use this for initialization
    void Start()
    {
        StartCoroutine("spawnItems");
    }

    public IEnumerator spawnItems()
    {
		GameObject itemSpawned;
        while (true)
        {
            int spawnloc = (int)Random.Range(0, spawnpoints.Length);

            int letterToSpawn = (int)Random.Range(0, ObjectsToSpawn.Length);

			itemSpawned = Instantiate(ObjectsToSpawn[letterToSpawn], spawnpoints[spawnloc].transform);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void SetSpawnDelay(float time) {
        spawnDelay = time;
    }
}
