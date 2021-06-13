using System.Collections;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    public GameObject meshObject;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 6)
            return;
        
        GameObject player1 = GameObject.FindWithTag("Player1");
        GameObject player2 = GameObject.FindWithTag("Player2");
        GameObject player = other.gameObject;

        if (player.CompareTag("Player1"))
        {
            GivePlayer1Powerup(player1, player2);
        }
        else if (player.CompareTag("Player2"))
        {
            GivePlayer2Powerup(player1, player2);
        }

        Destroy(meshObject);
        Destroy(gameObject.GetComponent<Collider>());
    }

    public abstract void GivePlayer1Powerup(GameObject player1, GameObject player2);
    public abstract void GivePlayer2Powerup(GameObject player1, GameObject player2);
    public abstract IEnumerator ResetPlayer1Powerup(GameObject player1, GameObject player2, float delay);
    public abstract IEnumerator ResetPlayer2Powerup(GameObject player1, GameObject player2, float delay);
}
