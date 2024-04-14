using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [Header("X movement")]
    [SerializeField] private float speed;
    [Header("Y movement")]
    [SerializeField] private float jump_force;
    [SerializeField] private float jump_detection_range;
    [SerializeField] private LayerMask ground_layer;
    private bool canJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, -transform.up, jump_detection_range, ground_layer);

        if (ray)
            canJump = true;
        else
            canJump = false;
    }

    public void Move(InputAction.CallbackContext con)
    {
        float dir_x = con.ReadValue<Vector2>().x;

        rb.velocity = new Vector2(dir_x * speed, rb.velocity.y);
    }

    public void Jump(InputAction.CallbackContext con)
    {
        if (con.performed && canJump)
        {
            rb.AddForce(transform.up * jump_force, ForceMode2D.Impulse);
        }
    }
}