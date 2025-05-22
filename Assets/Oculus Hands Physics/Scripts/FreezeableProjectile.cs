using UnityEngine;

public class FreezeableProjectile : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 savedVelocity;
    private Vector3 savedAngularVelocity;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Freeze()
    {
        savedVelocity = rb.velocity;
        savedAngularVelocity = rb.angularVelocity;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
    }

    public void Unfreeze()
    {
        rb.isKinematic = false;
        rb.velocity = savedVelocity;
        rb.angularVelocity = savedAngularVelocity;
    }
}