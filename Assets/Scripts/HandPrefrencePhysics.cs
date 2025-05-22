using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPrefrencePhysics : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;

    public Renderer nonPhysicalHand;
    private Collider[] handColliders;

    public float showNonePhysicalHandDistence = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        handColliders = GetComponentsInChildren<Collider>(); // اصلاح شد
    }


    public void EnableHandColliders()
    {
        foreach (var item in handColliders)
        {
            item.enabled = true;
        }
    }

    public void DisableHandColliders()
    {
        foreach (var item in handColliders)
        {
            item.enabled = false;
        }
    }

    public void EnableHandColliderDelay(float delay)
    {
        Invoke("EnableHandCollider",delay );
    }

    // Update is called once per frame
    private void Update()
    {
        float dist = Vector3.Distance(transform.position, target.position);
        if (dist > showNonePhysicalHandDistence)
        {
            nonPhysicalHand.enabled = true;
        }
        else
        {
            nonPhysicalHand.enabled = false;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = (target.position - transform.position)/Time.fixedDeltaTime;
        Quaternion rotationDefrence = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDefrence.ToAngleAxis(out float angleInDegrees, out Vector3 rotationAxis);
        Vector3 rotationAxisInDegrees = rotationAxis * angleInDegrees;
        rb.angularVelocity = (rotationAxisInDegrees*Mathf.Deg2Rad/Time.fixedDeltaTime);
    }
}
