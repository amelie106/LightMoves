
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class movement : MonoBehaviour
{
    //[SerializeField] 
    private Vector3 target = new Vector3(7, 5, 0);
    //[SerializeField] 
    public float speed = 5;

    public float currentTime;
 //   public float timeDifference;

    private float randomXposition, randomYposition;
    
    void Start()
        {
            //InvokeRepeating("SpawnNewEnemy", 0f, spawnPeriodInSec);
            currentTime = 0;
        }
    //private void SpawnNewEnemy()

    private void Update()
    {
        currentTime += Time.deltaTime;
        //randomXposition = UnityEngine.Random.Range(-10f, 10f);
        //randomYposition = UnityEngine.Random.Range(-6f, 6f);
        
        if(currentTime >= 5){
            //Destroy(gameObject, 0.12f);
            
            randomXposition = UnityEngine.Random.Range(-10f, 10f);
            randomYposition = UnityEngine.Random.Range(-6f, 6f);
        
            target = new Vector3(randomXposition, randomYposition, 0);
            // Moves the object to target position
            Destroy(gameObject, 3f);
            currentTime = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }
}