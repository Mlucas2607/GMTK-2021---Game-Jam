using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCollected : MonoBehaviour
{
    public RaycastSight ray;
   void PickupCollected_Flower()
    {
        ray.PickupTulip();
    }
}
