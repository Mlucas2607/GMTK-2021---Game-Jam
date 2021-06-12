using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTestUIManager : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text timer;
    public TMP_Text obstacles;
    public TMP_Text bonusCount;
    public TMP_Text bonusScore;
    public TMP_InputField bonusInput;
    public TMP_Text highScore;

    // Update is called once per frame
    void Update()
    {
        timer.text = ScoreSystem.GetInstance().TimeElapsed.ToString();
        score.text = ScoreSystem.GetInstance().Score.ToString();
        obstacles.text = ScoreSystem.GetInstance().ObstacleCollisions.ToString();
        bonusCount.text = ScoreSystem.GetInstance().BonusesCount.ToString();
        bonusScore.text = ScoreSystem.GetInstance().Bonuses.ToString();
        highScore.text = ScoreSystem.GetInstance().HighScore.ToString();
    }

    public void AddBonus()
    {
        ScoreSystem.GetInstance().AddBonus(int.Parse(bonusInput.text));
    }

    public void EndGame()
    {
        ScoreSystem.GetInstance().StopScoreTime();
        SceneManager.LoadScene("ScoreScene");
    }
}
