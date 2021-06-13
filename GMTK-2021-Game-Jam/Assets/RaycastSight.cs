using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSight : MonoBehaviour
{
    [Header("Variables")]
    public Transform pointA;
    public Transform pointB;

    public GameObject husbandHappy,husbandSad;
    public GameObject wifeHappy,wifeSad;

    public LineRenderer lineRend;

    public float rayDis = 100f;

    private void Update()
    {
        Vector3 lookDir = pointB.position - pointA.position;

        Ray lookRay = new Ray(pointA.position, lookDir);
        RaycastHit hit;

        Physics.Raycast(lookRay, out hit, 100);
        if (hit.collider == null)
            return;
        if (hit.collider.tag == "Player")
        {
            //can be seen
            ManageState(2);
            Debug.DrawRay(pointA.position, lookDir, Color.blue);

            lineRend.enabled = true;
            lineRend.SetPosition(0, pointA.position);
            lineRend.SetPosition(1, pointB.position);
        }
        else
        {
            //Cant be seen
            ManageState(1);
            Debug.DrawRay(pointA.position, lookDir, Color.red);
            lineRend.enabled = false;
        }

        void ManageState(int index)
        {
            //Sloppy code too laxzy to do properly :(
            if(index == 1)
            {
                husbandHappy.SetActive(false);
                husbandSad.SetActive(true);

                wifeHappy.SetActive(false);
                wifeSad.SetActive(true);
            }

            if (index == 2)
            {
                husbandHappy.SetActive(true);
                husbandSad.SetActive(false);

                wifeHappy.SetActive(true);
                wifeSad.SetActive(false);
            }
        }
    }
}
