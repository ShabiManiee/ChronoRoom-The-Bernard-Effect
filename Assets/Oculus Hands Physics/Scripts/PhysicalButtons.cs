using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicalButtons : MonoBehaviour
{
    [SerializeField] private float deadZone = 0.025f;
    [SerializeField] private float treshold = 0.1f;
    [SerializeField] private bool toggleFreeze = true;

    private bool _ispressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    public UnityEvent onPressed, onReleased;

    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    private float GetValue()
    {
        var value = Vector3.Distance(transform.localPosition, _startPos) / _joint.linearLimit.limit;
        if (Math.Abs(value) < deadZone)
            value = 0;
        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Press()
    {
        _ispressed = true;
        onPressed.Invoke();

        if (toggleFreeze && TimeManager.instance != null)
        {
            TimeManager.instance.ToggleTime(); // پاز/آنپاز کردن فقط آبجکت‌های خاص
        }
    }

    private void Release()
    {
        _ispressed = false;
        onReleased.Invoke();
    }

    void Update()
    {
        float value = GetValue();

        if (!_ispressed && value + treshold >= 1f)
            Press();

        if (_ispressed && value + treshold <= 0f)
            Release();
    }
}