using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RaycastSight : MonoBehaviour
{
    [Header("Variables")]
    public Transform pointA;
    public Transform pointB;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI fishText;
    public TextMeshProUGUI tulipText;
    public TextMeshProUGUI timerText;

    public float hpPercent = 100f;
    public float hpDecayRate = 0.5f;

    public int fishCount;
    public int tulipCount;

    public float healRate = 1f;

    public LayerMask rayMask;

    public GameObject husbandHappy,husbandSad;
    public GameObject wifeHappy,wifeSad;

    public LineRenderer lineRend;

    public float rayDis = 100f;

    [Header("WinLoseVars")]
    public GameObject gameOverScreen;

    [Header("Timer")]
    private float timer;


    [Header("Statics Vars")]
    public static float endTimer;

    private void Update()
    {
        Timer();

        Debug.Log(fishCount);
        Debug.Log(tulipCount);
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
        UpdateText();

        if (fishCount >= 5 && tulipCount >= 55)
        {
            SetSaticVariables();
            SceneManager.LoadScene(2);
        }

    }

    void Timer()
    {
        timer += 1 * Time.deltaTime;
        timerText.text = (int)timer + " :Seconds";
    }
    void UpdateText()
    {
        int p = (int)hpPercent;
        hpText.text = p + "%";

        fishText.text = fishCount + "/5";
        tulipText.text = tulipCount + "/5";
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
            gameOverScreen.SetActive(true);
    }

    public void PickupCollected()
    {
        if (fishCount > 5)
            return;
        fishCount++;
    }

    public void PickupTulip()
    {
        if (tulipCount > 5)
            return;
        tulipCount++;
    }

    public void SetSaticVariables()
    {
        endTimer = timer;
    }
}
