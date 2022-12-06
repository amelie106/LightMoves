using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//disappear when another spawns

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroid;

    private GameObject newAsteroid;
    private SpriteRenderer rend;
    private int randomSpawnZone;
    private float randomXposition, randomYposition;
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnNewAstro", 0f, 3f);

    }
    //private float delay = 12.0; //This implies a delay of 2 seconds.
 
    // private void WaitAndDestroy()
    // {
    //     yield WaitForSeconds(delay);
    //     Destroy (gameObject);
    // }

    private void SpawnNewAstro()
    {
        randomSpawnZone = Random.Range(0,4);

        switch (randomSpawnZone)
        {
            case 0:
                randomXposition = Random.Range(-1f, 0f);
                randomYposition = Random.Range(0f, 0f);
                break;
            case 1:
                randomXposition = Random.Range(-3f, 0f);
                randomYposition = Random.Range(-3f, -4f);
                break;
            case 2:
                randomXposition = Random.Range(2f, 3f);
                randomYposition = Random.Range(-2f, 2f);
                break; 
            case 3:
                randomXposition = Random.Range(-1f, 2f);
                randomYposition = Random.Range(2f, 3f);
                break;
        }
        spawnPosition = new Vector3(randomXposition, randomYposition, 0f);
        newAsteroid = Instantiate(asteroid, spawnPosition, Quaternion.identity);
        rend = newAsteroid.GetComponent<SpriteRenderer>();
        Destroy(rend, 12.0f);

    }
}
       
