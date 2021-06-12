using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Variables")]
    public float speed;

    public InputAction wasd;
    public InputAction ijkl;
    public Rigidbody rb;

    public bool is2nd;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        wasd.Enable();
        ijkl.Enable();
    }

    private void OnDisable()
    {
        wasd.Disable();
        ijkl.Disable();
    }
    private void Update()
    {
        Vector2 inputVector = new Vector2();

        if (is2nd)
            inputVector = ijkl.ReadValue<Vector2>() * speed;
        else
            inputVector = wasd.ReadValue<Vector2>() * speed;

        Vector3 finalVector = new Vector3(inputVector.x,rb.velocity.y,inputVector.y);
        rb.velocity = finalVector;
    }
}
