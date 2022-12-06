// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System

// public class health 
// {
//     int _currentHealth;
//     int _currentMaxHealth;


//     public int Health;
//     {
//         get
//         {
//             return _currentHealth;
//         }
//         set 
//         {
//             return _currentMaxHealth;
//         }

//     }
//     public int MaxHealth
// }


// // using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class movement : MonoBehaviour
// {
//     // Start is called before the first frame update
//     public static int movespeed = 1;
//     public Vector3 userDirection = Vector3.right;
//     void Start()
//     {
//         // Changes the position to x:1, y:1, z:0
//         transform.position = new Vector3(1, 1, 0);
        
//         // Moving object on a single axis
//         Vector3 newPosition = transform.position; // We store the current position
//         newPosition.y = 100; // We set a axis, in this case the y axis
//         transform.position = newPosition; // We pass it back
//  }
//  private void Update()
//  {
//  // We add +1 to the x axis every frame.
//  // Time.deltaTime is the time it took to complete the last frame
//  // The result of this is that the object moves one unit on the x axis every second
//         transform.position += new Vector3(1 * Time.deltaTime, 0, 0);
//  }
// }


// using UnityEngine;
// using System;
// using UnityEngine.UI;
// using System.Collections;
// using System.Collections.Generic;

// public class movement : MonoBehaviour
// {
//     //[SerializeField] 
//     private Vector3 target = new Vector3(7, 5, 0);
//     //[SerializeField] 
//     public float speed = 3;

//     public float currentTime;
//  //   public float timeDifference;

//     private float randomXposition, randomYposition;
    
//     void Start()
//         {
//             //InvokeRepeating("SpawnNewEnemy", 0f, spawnPeriodInSec);
//             currentTime = 0;
//         }
//     //private void SpawnNewEnemy()

//     private void Update()
//     {
//         currentTime += Time.deltaTime;
//         //randomXposition = UnityEngine.Random.Range(-10f, 10f);
//         //randomYposition = UnityEngine.Random.Range(-6f, 6f);
        
//         if(currentTime >= 5){
//             //Destroy(gameObject, 0.12f);
            
//         randomXposition = UnityEngine.Random.Range(-10f, 10f);
//         randomYposition = UnityEngine.Random.Range(-6f, 6f);
        
//             //target = new Vector3(randomXposition, randomYposition, 0);
//             // Moves the object to target position
            
//             currentTime = 0;
//         }
//         transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
//     }
// }