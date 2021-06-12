using System;
using System.Collections;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int Score
    {
        get
        {
            int obstacles = ObstacleCollisions * -200;
            if (obstacles == 0)
                obstacles = 1000;

            return TimeScore + obstacles + Bonuses;
        }
    }

    public int TimeScore
    {
        get
        {
            int time = 0;
            if (TimeElapsed > 300)
                time -= 100 * (TimeElapsed - 300);
            else
                time += 100 * (300 - TimeElapsed);

            return time;
        }
    }

    public int HighScore => PlayerPrefs.GetInt("highScore", 0);

    public int ObstacleCollisions { get; private set; }
    public int TimeElapsed { get; private set; }
    public int Bonuses { get; private set; }
    public int BonusesCount { get; private set; }

    public void IncrementObstacleCollision()
    {
        ObstacleCollisions++;
    }

    public void AddBonus(int bonus)
    {
        Bonuses += bonus;
        BonusesCount++;
    }

    public void SaveHighScore()
    {
        if (Score > HighScore)
        {
            PlayerPrefs.SetInt("highScore", Score);
            PlayerPrefs.Save();
        }
    }

    private IEnumerator UpdateTime()
    {
        for (;;)
        {
            TimeElapsed++;
            yield return new WaitForSeconds(1f);
        }
    }
    
    public void StartScoreTime()
    {
        StartCoroutine(nameof(UpdateTime));
    }

    public void StopScoreTime()
    {
        StopAllCoroutines();
    }

    private static ScoreSystem instance;

    public static ScoreSystem GetInstance()
    {
        return instance;
    }

    public static void ResetScore()
    {
        Destroy(instance.gameObject);
        instance = null;
    }
    
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
}
