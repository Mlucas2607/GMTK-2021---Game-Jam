using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaycastSight : MonoBehaviour
{
    [Header("Variables")]
    public Transform pointA;
    public Transform pointB;
    public TextMeshProUGUI hpText;
    
    public float hpPercent = 100f;
    public float hpDecayRate = 0.5f;

    public float healRate = 1f;

    public LayerMask rayMask;

    public GameObject husbandHappy,husbandSad;
    public GameObject wifeHappy,wifeSad;

    public LineRenderer lineRend;

    public float rayDis = 100f;

    private void Update()
    {
        IfDead();

        Vector3 lookDir = pointB.position - pointA.position;

        Ray lookRay = new Ray(pointA.position, lookDir);
        RaycastHit hit;

        Physics.Raycast(lookRay, out hit, 100, rayMask);
        if (hit.collider == null)
            return;
        if (hit.collider.tag == "Player")
        {
            //can be seen
            ManageState(2);

            lineRend.enabled = true;
            lineRend.SetPosition(0, pointA.position);
            lineRend.SetPosition(1, pointB.position);
            Heal();
        }
        else
        {
            //Cant be seen
            ManageState(1);
            Debug.DrawRay(pointA.position, lookDir, Color.red);
            lineRend.enabled = false;
            if (hpPercent <= 0)
                return;
            hpPercent -= hpDecayRate * Time.deltaTime;
        }
        int p = (int)hpPercent;
        hpText.text = p + "%";
    }
    void ManageState(int index)
        {
        //Sloppy code too lazy to do properly :(
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

    void Heal()
    {
        if (hpPercent >= 100)
            return;
        hpPercent += healRate * Time.deltaTime;
    }

    void IfDead()
    {
        if (hpPercent <= 0)
            Debug.Log("Gameover");
    }
    
}
