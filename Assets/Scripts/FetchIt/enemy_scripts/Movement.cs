
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour
{
    private Vector3 target = new Vector3(7, 5, 0);

    [SerializeField] 
    public float speed;

    public float currentTime;
    private float randomXposition, randomYposition;
    
    void Start()
        {
            randomXposition = UnityEngine.Random.Range(-10f, 10f);
            randomYposition = UnityEngine.Random.Range(-6f, 6f);
        
            target = new Vector3(randomXposition, randomYposition, 0);
            currentTime = 0;
        }

    private void Update()
    {
        currentTime += Time.deltaTime;
        
        if(currentTime >= 5){
            randomXposition = UnityEngine.Random.Range(-10f, 10f);
            randomYposition = UnityEngine.Random.Range(-6f, 6f);
        
            target = new Vector3(randomXposition, randomYposition, 0);
            
            currentTime = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }
}