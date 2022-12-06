using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//end of game on destroy


public class enemydestroy : MonoBehaviour
{
    //private Animator anim;
    public float health;
    public bool alive = true;
    public Image healthBar;
    AudioSource audiodata;

    void Start()
    {
        //anim = GetComponent<Animator>();
        health = 80;
        healthBar.fillAmount = health / 80;
    }
    void Update()
    {
            
        //if (alive == false){
            //StopGame();
        //}

    }
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Asteroid")
        {
            audiodata = GetComponent<AudioSource>();
            audiodata.Play(0); 
            health -= 10;
            healthBar.fillAmount = health / 80;
            
            if (health == 0){
                
                alive = false;

                Application.Quit();
                SceneManager.LoadScene("AfterDeath");

            }
        }
    }
    void StopGame()
    {
        Application.Quit();
    }
}
