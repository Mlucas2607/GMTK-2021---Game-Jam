using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherCreator : MonoBehaviour
{
    public GameObject anchorPoint1;
    public GameObject anchorPoint2;
    public GameObject tetherPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // get distance between anchor points
        var anchorPoint1Position = anchorPoint1.transform.position;
        var anchorPoint2Position = anchorPoint2.transform.position;
        float distanceBetweenPoints = Vector3.Distance(anchorPoint1Position, anchorPoint2Position);

        // divide the distance by the object x scale to get number of string objects required
        float tetherObjectSize = tetherPrefab.GetComponent<Renderer>().bounds.size.x;
        int objectRequired = (int)(distanceBetweenPoints / tetherObjectSize);

        // create a vector with the direction towards the second anchor point with its length
        // being how far to move to create the next object (add object x scale?)
        Vector3 directionVector = anchorPoint2Position - anchorPoint1Position;
        directionVector = directionVector.normalized * tetherObjectSize;

        // create an object at anchor point 1 + directionVector
        GameObject lastObject = anchorPoint1;

        // add the vector we created onto the position of the last object

        // create the second object, changing the spring joint connected body to the previous object

        // repeat until we have the number of string objects required

        for (int i = 0; i < objectRequired; i++)
        {
            GameObject currentObject = GameObject.Instantiate(tetherPrefab, lastObject.transform.position + directionVector, Quaternion.identity);
            currentObject.GetComponent<SpringJoint>().connectedBody = lastObject.GetComponent<Rigidbody>();
            lastObject = currentObject;
        }
        anchorPoint2.GetComponent<SpringJoint>().connectedBody = lastObject.GetComponent<Rigidbody>();

        // destroy this script or object
        Destroy(this);
    }
}
