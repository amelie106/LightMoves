using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public bool isDestroyed = false;

public class death : MonoBehaviour
{
    private Animator anim;
    AudioSource audiodata;

    void Start()
    {
        anim = GetComponent<Animator>();
        // GetComponent<AudioSource> ().playOnAwake = false;
        // GetComponent<AudioSource> ().clip = saw;
    }
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(collision.gameObject);
            anim.Play("explosion");
            audiodata = GetComponent<AudioSource>();
            audiodata.Play(0);
            if(gameObject != null){
                //isDestroyed = true;
                Destroy(gameObject, 0.12f); 
            }

        }
    }
}
