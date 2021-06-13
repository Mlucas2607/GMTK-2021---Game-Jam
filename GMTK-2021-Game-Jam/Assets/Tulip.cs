using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tulip : MonoBehaviour
{
    public float rotSpeed = 20f;
    private void Update()
    {
        transform.Rotate(new Vector3(0, rotSpeed, 0));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            other.SendMessage("PickupCollected_Flower");
        }
    }
}
