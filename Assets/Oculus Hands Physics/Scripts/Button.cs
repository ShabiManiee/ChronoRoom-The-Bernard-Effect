using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Transform visualTarget;
    public string triggeringTag = "Hand"; // یا "Player" یا "Finger" یا هر چیزی که روی دست‌ت تگ گذاشتی
    public float cooldownTime = 1f;

    private bool isPressed = false;
    private bool onCooldown = false;

    private Vector3 initialLocalPos;

    void Start()
    {
        if (visualTarget != null)
        {
            initialLocalPos = visualTarget.localPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (onCooldown || isPressed)
            return;

        if (other.CompareTag(triggeringTag))
        {
            Debug.Log("Trigger entered by: " + other.name);
            isPressed = true;
            ToggleTime();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggeringTag))
        {
            Debug.Log("Trigger exited by: " + other.name);
            isPressed = false;
        }
    }

    private void ToggleTime()
    {
        if (TimeManager.instance != null)
        {
            Debug.Log("Toggling Time!");
            TimeManager.instance.ToggleTime();
            StartCoroutine(CooldownRoutine());
        }
        else
        {
            Debug.LogWarning("TimeManager.instance is null");
        }
    }

    private System.Collections.IEnumerator CooldownRoutine()
    {
        onCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
    }
}