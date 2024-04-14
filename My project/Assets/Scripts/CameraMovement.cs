using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;         
    [SerializeField] private float speed = 0.125f;
    [SerializeField] private Vector2 offset;           

    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        smoothedPosition.z = -10;
        transform.position = smoothedPosition;
    }
}