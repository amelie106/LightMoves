using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//dont spawn on one another
//add death
public class bonusSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float spawnPeriodInSec;

    private GameObject newEnemy;
    private SpriteRenderer rend;
    private int randomSpawnZone;
    private float randomXposition, randomYposition;
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnNewEnemy", 4f, spawnPeriodInSec);

    }
    private void SpawnNewEnemy()
    {
        randomSpawnZone = Random.Range(0,4);

        
        randomXposition = Random.Range(-7f, 7f);
        randomYposition = Random.Range(-5f, 5f);

        spawnPosition = new Vector3(randomXposition, randomYposition, 0f);
        newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        rend = newEnemy.GetComponent<SpriteRenderer>();
        Destroy(newEnemy, 12.0f);

    }
}
       
