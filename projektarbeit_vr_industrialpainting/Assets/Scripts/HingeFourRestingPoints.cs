using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HingeFourRestingPoints : XRGrabInteractable
{
    HingeJoint hinge;
    [SerializeField] float restingPoint1 = 0f;
    [SerializeField] float restingPoint2 = 90f;
    [SerializeField] float restingPoint3 = 180f;
    [SerializeField] float restingPoint4 = 270f;
    [SerializeField] float springForce;
    [SerializeField] float damper;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
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
        Debug.Log("Current Angle: " + currentAngle);

        // Create an array of resting points.
        float[] restingPoints = new float[] { restingPoint1, restingPoint2, restingPoint3, restingPoint4 };

        // Determine which resting point is closest.
        float targetAngle = restingPoints[0];
        float minDiff = Mathf.Abs(currentAngle - restingPoints[0]);
        for (int i = 1; i < restingPoints.Length; i++)
        {
            float diff = Mathf.Abs(currentAngle - restingPoints[i]);
            if (diff < minDiff)
            {
                minDiff = diff;
                targetAngle = restingPoints[i];
            }
        }

        // Set up the spring to snap to the nearest resting point.
        JointSpring spring = hinge.spring;
        spring.spring = springForce;
        spring.damper = damper;
        spring.targetPosition = targetAngle;
        hinge.spring = spring;
        hinge.useSpring = true;
        
        Debug.Log("Snapping to: " + targetAngle);
    }
}
