using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DynamicPlatform : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public List<Vector2> destinations;
    public int currentDestination;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, destinations[currentDestination], speed);
        if (Vector2.Distance(transform.position, destinations[currentDestination]) < 0.05f
            && currentDestination < destinations.Count - 1)
        {
            currentDestination++;
        }
        else if (currentDestination == destinations.Count - 1)
            currentDestination = 0;
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < destinations.Count; i++)
        {
            Gizmos.DrawWireSphere(destinations[i], 1);
        }
    }
}