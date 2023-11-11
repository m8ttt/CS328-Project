using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float followSpeed;

    public Transform target;

    private Vector3 v = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 targetPos = target.position + offset;
        targetPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref v, followSpeed);
    }
}
