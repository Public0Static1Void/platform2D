using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private LayerMask enemyLayer;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void Attack(InputAction.CallbackContext con)
    {
        if (con.performed)
        {
            switch (spriteRenderer.flipX)
            {
                case true:
                    RaycastHit2D ray_r = Physics2D.Raycast(transform.position, transform.right, range, enemyLayer);
                    if (ray_r)
                        EnemyHit(ray_r.transform.gameObject);
                    break;
                case false:
                    RaycastHit2D ray_l = Physics2D.Raycast(transform.position, -transform.right, range, enemyLayer);
                    if (ray_l)
                        EnemyHit(ray_l.transform.gameObject);
                    break;
            }
        }
    }

    private void EnemyHit(GameObject enemy)
    {
        // do something
    }
}