using Rope;
using UnityEngine;

public class RopeFragmentChecker : MonoBehaviour
{
    public float maxDistance;

    [HideInInspector]
    public RopeController ropeController;

    private Transform otherObject;

    private void Update()
    {
        var heading = otherObject.position - transform.position;
        
        if (heading.sqrMagnitude > maxDistance * maxDistance) {
            Break();
        }
    }

    private void Break()
    {
        // TODO: Game over code
        
        ropeController.BreakRope();

        Destroy(this);
    }

    private void Start()
    {
        otherObject = GetComponent<SpringJoint>().connectedBody.transform;
    }
}
