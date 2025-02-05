using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CafeMill : MonoBehaviour
{
    [SerializeField] Sieve sieve;

    [SerializeField] GameObject sieveGameObject;

    BoxCollider sieveCollider; 

    [SerializeField] XRGrabInteractable sieveInteractable;
    
    [SerializeField] GameObject grindDegreeSwitch;
    [SerializeField] XRSocketInteractor socketInteractor;

    HingeJoint grindDegreeSwitchJoint;
    public int grindDegree;

    bool fillSieve = false;

    // Start is called before the first frame update
    void Start()
    {
        grindDegreeSwitchJoint = grindDegreeSwitch.GetComponent<HingeJoint>();
        sieveCollider = sieveGameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grindDegreeSwitchJoint.angle >= (-45f) && grindDegreeSwitchJoint.angle <= (45f))
        {
            grindDegree = 1;
        }
        else if (grindDegreeSwitchJoint.angle > (45f) && grindDegreeSwitchJoint.angle <= (135f))
        {
            grindDegree = 2;
        }
        else if (grindDegreeSwitchJoint.angle > (135f) && grindDegreeSwitchJoint.angle <= (225f))
        {
            grindDegree = 3;
        }
        else if (grindDegreeSwitchJoint.angle > (225f) && grindDegreeSwitchJoint.angle <= (270f))
        {
            grindDegree = 4;
        }

        if (socketInteractor.hasSelection && !fillSieve && !sieve.containsCafe)
        {
            fillSieve = true;
            sieveCollider.enabled = false;  
            StartCoroutine(FillSieveWithCafe());
        }
    }

    IEnumerator FillSieveWithCafe()
    {
        Debug.Log("Start Filling");
        yield return new WaitForSeconds(5);
        sieve.cafeGrindDegree = grindDegree;
        sieve.containsCafe = true;
        sieveCollider.enabled = true;  
        fillSieve = false;
        Debug.Log("Filled");
    } 
}
