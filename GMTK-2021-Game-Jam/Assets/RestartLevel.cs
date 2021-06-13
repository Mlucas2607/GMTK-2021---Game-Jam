using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class RestartLevel : MonoBehaviour
{
    public InputAction space;

    private void OnEnable()
    {
        space.Enable();
    }

    private void OnDisable()
    {
        space.Enable();
    }

        private void Update()
    {
        if (space.triggered)
        {
            Debug.Log("RealodSceje");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("RealodSceje");
        }

    }
}
