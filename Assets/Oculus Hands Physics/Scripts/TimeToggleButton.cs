using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TimeToggleButton : MonoBehaviour
{
    private XRBaseInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.selectEntered.AddListener(OnPressed);
    }

    private void OnPressed(BaseInteractionEventArgs args)
    {
        TimeManager.instance.ToggleTime();
    }
}