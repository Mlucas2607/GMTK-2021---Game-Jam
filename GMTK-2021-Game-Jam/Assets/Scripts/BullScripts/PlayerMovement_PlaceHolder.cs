using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_PlaceHolder : MonoBehaviour
{
    [Header("Player Variables")]
    public float speed;

    private void Update()
    {
        Move();
    }

    void Move()
    {
        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(xDir, 0, zDir);
        this.transform.Translate(moveDir * speed * Time.deltaTime);
    }
}
