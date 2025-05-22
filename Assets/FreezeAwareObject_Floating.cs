using System;
using UnityEngine;

public class FreezeAwareObject_Floating : MonoBehaviour
{
    private FloatingMotion floating;

    private void Awake()
    {
        floating = GetComponent<FloatingMotion>();
    }
    

    public void ApplyFreeze(bool freeze)
    {
        if (floating != null)
        {
            floating.SetFrozen(freeze);
        }
    }
}