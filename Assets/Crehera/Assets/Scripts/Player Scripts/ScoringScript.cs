using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringScript : MonoBehaviour
{
    public Text scoreText;
    int currentScore;
    int highScore;
    int totalScore;
    int currentMedalIndex;
    int intermediateScore;
    
    string[] medalNames = new string[] {"None :(", "Bronze", "Silver", "Gold"};
    int[] medalValues = new int[] { 0,5,10,15 };


    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        currentMedalIndex = 0;
        highScore = PlayerPrefs.GetInt("highscoreFetch");
        totalScore = PlayerPrefs.GetInt("totalScore");
        
        scoreText.text = @"Highscore: " + highScore.ToString() + "\nPoints Collected: " + currentScore.ToString() + 
                        "\nCurrent Medal: " + medalValues[currentMedalIndex] + "\n" + intermediateScore.ToString() + " / " + 
                        medalValues[currentMedalIndex+1] + " for " + medalNames[currentMedalIndex+1];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision){
        // System.Log()
        // scoreText.text = "okay";
        if (collision.gameObject.tag == "Diamond")
        {

            currentScore += 1;
            intermediateScore += 1;

            if(totalScore + currentScore > highScore) {
                UpdateHighScore();
            }

            if (currentMedalIndex != 3) {
                if(intermediateScore == medalValues[currentMedalIndex+1]) {
                    if (currentMedalIndex != 3) {
                        currentMedalIndex += 1;
                        intermediateScore = 0;
                    }
                }
                scoreText.text = @"Highscore: " + highScore.ToString() + "\nPoints Collected: " + currentScore.ToString() + 
                        "\nCurrent Medal: " + medalNames[currentMedalIndex] + "\n" + intermediateScore.ToString() + " / " + 
                        medalValues[currentMedalIndex+1] + " for " + medalNames[currentMedalIndex+1];
                
            }
            else {
                scoreText.text = @"Highscore: " + highScore.ToString() + "\nPoints Collected: " + currentScore.ToString() + 
                        "\nCurrent Medal: " + medalValues[currentMedalIndex] + "\nGood Job! You earned the highest medal :)";
            }

        }
    }

    public void UpdateHighScore () {
        highScore = totalScore + currentScore;
        PlayerPrefs.SetInt("highscoreFetch", totalScore + currentScore);
        PlayerPrefs.Save();
    }

    public void UpdateTotalScore () {
        PlayerPrefs.SetInt("totalScore", totalScore);
        PlayerPrefs.Save();
    }
    
}
