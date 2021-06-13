using System.Collections;
using UnityEngine;

public class FishPowerup : Powerup
{
    public float speedIncrease;
    public float speedIncreaseTime;
    public float invincibilityTime;
    
    public override void GivePlayer1Powerup(GameObject player1, GameObject player2)
    {
        // TODO: Add invincibility
    }

    public override void GivePlayer2Powerup(GameObject player1, GameObject player2)
    {
        player1.GetComponent<PlayerMovement>().speed += speedIncrease;
        player2.GetComponent<PlayerMovement>().speed += speedIncrease;
        StartCoroutine(ResetPlayer2Powerup(player1, player2, speedIncreaseTime));
    }

    public override IEnumerator ResetPlayer1Powerup(GameObject player1, GameObject player2, float delay)
    {
        yield return new WaitForSeconds(delay);
        // TODO: Reset invincibility
    }

    public override IEnumerator ResetPlayer2Powerup(GameObject player1, GameObject player2, float delay)
    {
        yield return new WaitForSeconds(delay);
        player1.GetComponent<PlayerMovement>().speed -= speedIncrease;
        player2.GetComponent<PlayerMovement>().speed -= speedIncrease;
    }
}