using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    public bool timeIsFrozen = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void ToggleTime()
    {
        timeIsFrozen = !timeIsFrozen;

        FreezeableProjectile[] projectiles = FindObjectsOfType<FreezeableProjectile>();

        foreach (var p in projectiles)
        {
            if (timeIsFrozen)
                p.Freeze();
            else
                p.Unfreeze();
        }
        foreach (var obj in FindObjectsOfType<FreezeAwareObject_Floating>())
        {
            Debug.Log("FreezeAware Floating Object: " + obj.name);
            obj.ApplyFreeze(timeIsFrozen);
        }
        
    }
}