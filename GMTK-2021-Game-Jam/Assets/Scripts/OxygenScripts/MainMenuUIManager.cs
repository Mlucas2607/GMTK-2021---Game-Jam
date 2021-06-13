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
        Application.OpenURL("https://sketchfab.com/3d-models/cats-rigged-and-posed-f38f91b5fa7b43968b8c45d5160b0268#download");
    }
    
    public void OpenLicenseLink2()
    {
        Application.OpenURL("https://creativecommons.org/licenses/by/4.0/");
    }
}
