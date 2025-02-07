using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Sieve : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    XRGrabInteractable sieveInteractor;
    [SerializeField] GameObject visualCafe;
    MeshRenderer visualCafeRenderer;

    [SerializeField] GameObject sieveTamperPressSocket;
    [SerializeField] XRSocketInteractor sieveTamperPressSocketInteractor;
    BoxCollider sieveTamperPressSocketCollider;
    [SerializeField] XRSocketInteractor sieveTamperToolSocketInteractor;

    [SerializeField] XRSocketInteractor tamperStationSocketInteractor;

    [SerializeField] AudioSource switchSound;

    public bool containsCafe;
    public bool isTampered;

    public bool isInTamperStation;
    public int cafeGrindDegree;
    // Start is called before the first frame update
    void Start()
    {
        sieveInteractor = GetComponent<XRGrabInteractable>();
        sieveInteractor.selectEntered.AddListener(OnObjectAttached);
        sieveInteractor.selectExited.AddListener(OnObjectDetached);

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

            if (gameManager.gameLevel == 1 && gameManager.tutorialStage == 4)
            {
                gameManager.stageStarted = false;
                gameManager.tutorialStage = 5;
            }
        }
        if (sieveTamperPressSocketInteractor.hasSelection && !isTampered && containsCafe){
            isTampered = true;
        }
        if (!sieveTamperPressSocketInteractor.hasSelection && isTampered && containsCafe){
            sieveTamperPressSocketCollider.enabled = false;

            if (gameManager.gameLevel == 1 && gameManager.tutorialStage == 5 && sieveTamperToolSocketInteractor.hasSelection)
            {
                gameManager.stageStarted = false;
                gameManager.tutorialStage = 6;
            }
        }
    }

    void OnObjectAttached(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRSocketInteractor)
        {
            switchSound.Play();
        }
    }

    void OnObjectDetached(SelectExitEventArgs args)
    {
        if (args.interactorObject is XRSocketInteractor)
        {
            switchSound.Play();
        }
    }
    
    void OnDestroy()
    {
        sieveInteractor.selectEntered.RemoveListener(OnObjectAttached);
        sieveInteractor.selectExited.RemoveListener(OnObjectDetached);
    }
}
