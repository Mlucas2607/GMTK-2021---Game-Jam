using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Variables")]
    public float speed;
    public float rotationSpeed;

    public InputAction wasd;
    public InputAction ijkl;
    public Rigidbody rb;

    public Animator animator;

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
        Move();
    }

    void Move()
    {
        Vector2 inputVector = new Vector2();

        if (is2nd)
            inputVector = ijkl.ReadValue<Vector2>() * speed;
        else
            inputVector = wasd.ReadValue<Vector2>() * speed;

        Vector3 finalVector = new Vector3(inputVector.x, 0, inputVector.y);
        rb.velocity = finalVector;

        if (finalVector != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(finalVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (animator == null)
            return;
        float speedNorm = rb.velocity.magnitude;
        animator.SetFloat("Speed", speedNorm);
    }
}
