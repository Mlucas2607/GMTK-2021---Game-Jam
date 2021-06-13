using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            Destroy(this.gameObject);
            other.SendMessage("PickupCollected");
        }
    }
}
