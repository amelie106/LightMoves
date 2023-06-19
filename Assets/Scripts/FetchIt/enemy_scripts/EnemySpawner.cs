using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float spawnPeriodInSec;

    private GameObject newEnemy; 
    private SpriteRenderer rend;
    private int randomSpawnZone;
    private float randomXposition, randomYposition;
    private Vector3 spawnPosition = new Vector3(0,0,0);
    public float radius;
    public Collider2D[] colliders;
    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnNewEnemy", 4f, spawnPeriodInSec);

    }
 
    private void SpawnNewEnemy()
    {
        bool canSpawnHere = false;
        int safetynet = 0;
        
        while(!canSpawnHere){
            randomSpawnZone = Random.Range(0,4);

            switch (randomSpawnZone)
            {
                case 0:
                    randomXposition = Random.Range(-11f, -7f);
                    randomYposition = Random.Range(0f, 0f);
                    break;
                case 1:
                    randomXposition = Random.Range(7f, 11f);
                    randomYposition = Random.Range(-3f, -4f);
                    break;
                case 2:
                    randomXposition = Random.Range(2f, 3f);
                    randomYposition = Random.Range(-8f, -5f);
                    break; 
                case 3:
                    randomXposition = Random.Range(-1f, 2f);
                    randomYposition = Random.Range(5f, 8f);
                    break;
            }
            spawnPosition = new Vector3(randomXposition, randomYposition, 0f);
            canSpawnHere = PreventSpawnOverlap (spawnPosition);
            if (canSpawnHere){
                break;
            }
            safetynet++;
            if (safetynet > 50){
                Debug.Log("Too many attempts");
                break;
            }

        }


        newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        rend = newEnemy.GetComponent<SpriteRenderer>();
        Destroy(newEnemy, 8.0f);

    }
    bool PreventSpawnOverlap(Vector3 spawnPosition){
        colliders = Physics2D.OverlapCircleAll (transform.position, radius, mask);
        for (int i = 0; i < colliders.Length; i++){
            Vector3 centerPoint = colliders [i].bounds.center;
            float width = colliders [i].bounds.extents.x;
            float height = colliders [i].bounds.extents.y;

            float leftExtent = centerPoint.x - width;
            float rightExtent = centerPoint.x + width;
            float lowerExtent = centerPoint.y - height;
            float upperExtent = centerPoint.y + height;
            
            if (spawnPosition.x >= leftExtent && spawnPosition.x <= rightExtent)
            {
                if (spawnPosition.y >= lowerExtent && spawnPosition.y <= upperExtent)
                {
                    return false;

                }
            }
            
            
        }
        return true;
    }
}
       
