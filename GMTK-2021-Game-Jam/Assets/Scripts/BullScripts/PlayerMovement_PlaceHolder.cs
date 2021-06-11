using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement_PlaceHolder : MonoBehaviour
{
    [Header("Player Variables")]
    public float speed;

    public InputAction wasd;
    public CharacterController controller;
    private void OnEnable()
    {
        wasd.Enable();
    }

    private void OnDisable()
    {
        wasd.Disable();
    }
    private void Update()
    {
        Vector2 inputVector = wasd.ReadValue<Vector2>();
        Vector3 finalVector = new Vector3(inputVector.x,0,inputVector.y);
        controller.Move(finalVector * Time.deltaTime * speed);
    }

 
}
