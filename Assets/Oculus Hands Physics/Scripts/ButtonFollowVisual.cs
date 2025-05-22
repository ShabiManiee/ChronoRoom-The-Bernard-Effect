using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonFollowVisual : MonoBehaviour
{
    public Transform visualTarget;
    public Vector3 localAxis = Vector3.down;
    public float resetSpeed = 5;
    public float followAngleThreshold = 45;

    private bool freeze = false;
    private Vector3 initialLocalPos;
    private Vector3 offset;
    private Transform pokeAttachTransform;

    private XRBaseInteractable interactable;
    private bool isFollowing = false;

    void Start()
    {
        initialLocalPos = visualTarget.localPosition;

        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(Follow);
        interactable.hoverExited.AddListener(Reset);
        interactable.selectEntered.AddListener(ToggleTime);
    }

    public void Follow(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor interactor)
        {
            isFollowing = true;
            pokeAttachTransform = interactor.attachTransform;
            offset = visualTarget.position - pokeAttachTransform.position;

            float pokeAngle = Vector3.Angle(offset, visualTarget.TransformDirection(localAxis));

            if (pokeAngle > followAngleThreshold)
            {
                isFollowing = false;
                freeze = true;
            }
        }
    }

    public void Reset(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            isFollowing = false;
            freeze = false;
        }
    }

    public void ToggleTime(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            TimeManager.instance.ToggleTime();
        }
    }
    private bool wasPressed = false;
    public float pressThreshold = 0.01f;

    void Update()
    {
        if (freeze)
            return;

        if (isFollowing)
        {
            Vector3 localTargetPosition = visualTarget.InverseTransformPoint(pokeAttachTransform.position + offset);
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargetPosition, localAxis);
            visualTarget.position = visualTarget.TransformPoint(constrainedLocalTargetPosition);
        }
        else
        {
            visualTarget.localPosition = Vector3.Lerp(visualTarget.localPosition, initialLocalPos, Time.deltaTime * resetSpeed);
        }

        float delta = initialLocalPos.y - visualTarget.localPosition.y;

        if (!wasPressed && delta > pressThreshold)
        {
            wasPressed = true;
            isFollowing = false; // ⬅️ این خط مهمه: قطع کردن دنبال کردن تا دکمه قفل نکنه

            Debug.Log("Button Pressed (via movement)");

            if (TimeManager.instance != null)
                TimeManager.instance.ToggleTime();
            else
                Debug.LogWarning("TimeManager.instance is null");
        }

        // وقتی دکمه به موقعیت بالا برگشت، آماده باشه برای فشردن بعدی
        if (wasPressed && delta < pressThreshold * 0.5f)
        {
            wasPressed = false;
        }
    }
}
