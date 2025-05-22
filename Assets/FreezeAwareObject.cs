using UnityEngine;

public class FreezeAwareObject : MonoBehaviour
{
    private Rigidbody rb;
    private bool originalKinematic;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalKinematic = rb.isKinematic;
    }

    public void ApplyFreeze(bool freeze)
    {
        if (freeze)
            rb.isKinematic = true;
        else
            rb.isKinematic = originalKinematic;
    }
}