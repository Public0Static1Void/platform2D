using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance {  get; private set; }

    private Rigidbody2D rb;
    [Header("X movement")]
    [SerializeField] private float speed;
    [Header("Y movement")]
    [SerializeField] private float jump_force;
    [SerializeField] private float jump_detection_range;
    [SerializeField] private LayerMask ground_layer;
    private bool canJump;

    private SpriteRenderer spriteRenderer;
    private Animator anim;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, -transform.up, jump_detection_range, ground_layer);

        if (ray)
            canJump = true;
        else
            canJump = false;

        if (rb.velocity.x >= 0)
            anim.SetFloat("x_velocity", rb.velocity.x);
        else
            anim.SetFloat("x_velocity", -rb.velocity.x);

        anim.SetFloat("y_velocity", rb.velocity.y);
        anim.SetBool("grounded", canJump);
    }

    public void Move(InputAction.CallbackContext con)
    {
        float dir_x = con.ReadValue<Vector2>().x;

        rb.velocity = new Vector2(dir_x * speed, rb.velocity.y);

        if (rb.velocity.x < 0)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
    }

    public void Jump(InputAction.CallbackContext con)
    {
        if (con.performed && canJump)
        {
            if (transform.parent != null)
                transform.parent = null;

            rb.AddForce(transform.up * jump_force, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DyPlatform"))
        {
            transform.SetParent(other.transform, true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("DyPlatform"))
        {
            transform.parent = null;
        }
    }
}