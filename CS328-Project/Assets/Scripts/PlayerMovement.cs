using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movingSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 moving;

    // Update is called once per frame
    void Update()
    {
        moving.x = Input.GetAxisRaw("Horizontal");
        moving.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moving * movingSpeed * Time.fixedDeltaTime);
    }
}
