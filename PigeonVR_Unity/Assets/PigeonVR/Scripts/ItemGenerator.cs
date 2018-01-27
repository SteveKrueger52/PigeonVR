using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    [SerializeField]
    GameObject[] spawnpoints;

    [SerializeField]
    float spawnDelay;

    [SerializeField]
    GameObject[] ObjectsToSpawn;


    // Use this for initialization
    void Start()
    {
        StartCoroutine("spawnItems");
    }

    public IEnumerator spawnItems()
    {
        while (true)
        {
            int spawnloc = (int)Random.Range(0, spawnpoints.Length);

            int letterToSpawn = (int)Random.Range(0, ObjectsToSpawn.Length);

            Instantiate(ObjectsToSpawn[letterToSpawn], spawnpoints[spawnloc].transform);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
