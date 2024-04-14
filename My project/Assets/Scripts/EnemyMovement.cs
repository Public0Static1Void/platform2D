using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private int life;

    private int dir;
    private bool damaged;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        dir = 1;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dir * speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            TakeDamage();
            dir *= -1;
        }
        if (coll.CompareTag("Wall"))
            dir *= -1;
    }

    public void TakeDamage()
    {
        if (damaged)
            return;

        StartCoroutine(InvulnerableTime());

        life--;
        if (life <= 0)
            Destroy(this.gameObject);
    }

    private IEnumerator InvulnerableTime()
    {
        damaged = true;
        yield return new WaitForSeconds(0.2f);
        damaged = false;
    }
}