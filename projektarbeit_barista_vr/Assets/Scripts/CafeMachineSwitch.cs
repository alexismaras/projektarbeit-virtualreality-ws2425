using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CafeMachineSwitch : XRGrabInteractable
{
    HingeJoint hinge;
    float restingPoint1;
    float restingPoint2;
    [SerializeField] float springForce;
    [SerializeField] float damper;

    public bool switchOn;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        restingPoint1 = hinge.limits.min;
        restingPoint2 = hinge.limits.max;
    }

    // Called when the object is grabbed.
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        // You might want to disable any snapping forces here,
        // so the user can freely move the lever.
    }

    // Called when the object is released.
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        OnLeverRelease();
    }

    // Your method to snap the lever to the nearest resting point.
    public void OnLeverRelease()
    {
        float currentAngle = hinge.angle;
        Debug.Log(currentAngle);
        float targetAngle = (Mathf.Abs(currentAngle - restingPoint1) < Mathf.Abs(currentAngle - restingPoint2))
                                ? restingPoint1 
                                : restingPoint2;


        JointSpring spring = hinge.spring;
        spring.spring = springForce;
        spring.damper = damper;
        spring.targetPosition = targetAngle;
        hinge.spring = spring;
        hinge.useSpring = true;
        Debug.Log("Snapping to: " + targetAngle);

    }

    void Update()
    {
        if (Mathf.Round(hinge.angle) == Mathf.Round(restingPoint1))
        {
            switchOn = false;
        }
        else if (Mathf.Round(hinge.angle) == Mathf.Round(restingPoint2))
        {
            switchOn = true;
        }
    }

    
}
