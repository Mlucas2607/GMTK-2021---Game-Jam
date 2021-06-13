using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreUIManager : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text highScore;
    public GameObject newHighScore;
    public TMP_Text obstaclesCollided;
    public TMP_Text timeElapsed;
    public TMP_Text bonuses;
    public TMP_Text ending;
    
    // Start is called before the first frame update
    void Start()
    {
        ScoreSystem scoreSystem = ScoreSystem.GetInstance();
        score.text = scoreSystem.Score.ToString();
        highScore.text += scoreSystem.HighScore.ToString();
        newHighScore.SetActive(scoreSystem.Score > scoreSystem.HighScore);
        scoreSystem.SaveHighScore();
        
        int collisions = scoreSystem.ObstacleCollisions;
        if (collisions == 0)
            obstaclesCollided.text += "You hit no obstacles! 1000 points!";
        else
            obstaclesCollided.text += $"Hit {collisions} obstacles = {collisions * -200} points";

        timeElapsed.text = $"You took {scoreSystem.TimeElapsed} seconds giving you a score of {scoreSystem.TimeScore}";
        bonuses.text = $"You got {scoreSystem.BonusesCount} bonuses totaling {scoreSystem.Bonuses} points";
        ending.text = $"You had {GetWeddingGrade(scoreSystem.Score)}!";
        
        // Can you please code up something like if {scoreSystem.TimeScore} <= 25000 then {WeddingGrade} = "Super Sexy Wedding"
        // Else If {scoreSystem.TimeScore} <= 20000 then {WeddingGrade} = "Amazing Wedding"
        // Else If {scoreSystem.TimeScore} <= 15000 then {WeddingGrade} = "Basic Wedding"
        // Else If {scoreSystem.TimeScore} <= 10000 then {WeddingGrade} = "Crappy Wedding"
        // Else if {scoreSystem.TimeScore} <= 5000 then {WeddingGrade} = "Disgusting Wedding"
        // Else if {scoreSystem.TimeScore} then {WeddingGrade} = "Failed Wedding"
        ScoreSystem.ResetScore();
    }

    public string GetWeddingGrade(int score)
    {
        if (score >= 25000)
            return "a Super Sexy Wedding";
        if (score >= 20000)
            return "an Amazing Wedding";
        if (score >= 15000)
            return "a basic wedding";
        if (score >= 10000)
            return "a crappy wedding";
        if (score >= 5000)
            return "a disgusting wedding";
        return "a failed wedding";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
