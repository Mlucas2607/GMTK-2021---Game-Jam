using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    public GameObject sceneTransition;
    
    public void Play()
    {
        FindObjectOfType<AudioManager>().Play("Play Button");
        sceneTransition.SetActive(true);
        FindObjectOfType<AudioManager>().FadeOut("Main Menu Music", 1f);
        Invoke(nameof(LoadScene), 1f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Main Menu Music");
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
