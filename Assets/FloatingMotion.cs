using UnityEngine;

public class FloatingMotion : MonoBehaviour
{
    public Vector3 floatDirection = new Vector3(0, 1, 0); // جهت حرکت
    public float floatSpeed = 0.1f; // سرعت حرکت
    public float floatRange = 0.5f; // دامنه نوسان

    private Vector3 startPos;
    private float offset;
    private bool isFrozen = false;

    void Start()
    {
        startPos = transform.position;
        offset = Random.Range(0f, 100f); // برای متفاوت بودن فاز بین چند آبجکت
    }

    void Update()
    {
        if (isFrozen) return;

        float movement = Mathf.Sin(Time.time * floatSpeed + offset) * floatRange;
        transform.position = startPos + floatDirection.normalized * movement;
    }

    public void SetFrozen(bool freeze)
    {
        isFrozen = freeze;
    }
}