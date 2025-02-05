using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Sieve : MonoBehaviour
{
    [SerializeField] GameObject visualCafe;
    MeshRenderer visualCafeRenderer;

    [SerializeField] GameObject sieveTamperPressSocket;
    [SerializeField] XRSocketInteractor sieveTamperPressSocketInteractor;
    BoxCollider sieveTamperPressSocketCollider;

    [SerializeField] XRSocketInteractor tamperStationSocketInteractor;
    public bool containsCafe;
    public bool isTampered;

    public bool isInTamperStation;
    public int cafeGrindDegree;
    // Start is called before the first frame update
    void Start()
    {
        visualCafeRenderer = visualCafe.GetComponent<MeshRenderer>();
        visualCafeRenderer.enabled = false;
        sieveTamperPressSocketCollider = sieveTamperPressSocket.GetComponent<BoxCollider>();
        sieveTamperPressSocketCollider.enabled = false;
        containsCafe = false;
        isTampered = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!visualCafeRenderer.enabled && containsCafe)
        {
            visualCafeRenderer.enabled = true;
        }

        if (tamperStationSocketInteractor.hasSelection && !isTampered && containsCafe)
        {
            sieveTamperPressSocketCollider.enabled = true;
        }
        if (sieveTamperPressSocketInteractor.hasSelection && !isTampered && containsCafe){
            isTampered = true;
        }
        if (!sieveTamperPressSocketInteractor.hasSelection && isTampered && containsCafe){
            sieveTamperPressSocketCollider.enabled = false;
        }
    }
}
