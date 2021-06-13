using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    public void Play()
    {
        // Add animation before loading game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenLicenseLink1()
    {
        Application.OpenURL("https://skfb.ly/6SUQF");
    }
    
    public void OpenLicenseLink2()
    {
        Application.OpenURL("https://creativecommons.org/licenses/by/4.0/");
    }
}
