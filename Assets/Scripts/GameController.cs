using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    //Spawns hazards
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(spawnWait);
        while(true)
        {
            for (int i = 0; i < hazardCount; i ++)
            {
                //Instantiate Hazards
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }
}
