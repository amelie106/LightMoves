using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Animator anim;
    AudioSource audiodata;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player") {
            anim.Play("explosion");
            audiodata = GetComponent<AudioSource>();
            audiodata.Play(0);
            if(gameObject != null){
                Destroy(gameObject, 0.12f); 
            }

        }
    }
}
