using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EnemyDestroy : MonoBehaviour
{
    public float health;
    public bool alive = true;
    public Image healthBar;
    AudioSource audiodata;

    void Start()
    {
        health = 80;
        healthBar.fillAmount = health / 80;
    }
    void Update()
    {
            
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
