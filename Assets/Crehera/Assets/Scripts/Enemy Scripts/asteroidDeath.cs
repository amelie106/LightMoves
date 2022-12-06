using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidDeath : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        //anim = GetComponent<Animator>();
    }
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(collision.gameObject);
            //anim.Play("astoexplo");
            Destroy(gameObject, 0.12f); 
        }
    }
}
