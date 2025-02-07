using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class CafeMachine : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [SerializeField] TMP_Text timeIndicator;
    [SerializeField] Switch cafeMachineSwitch;
    [SerializeField] Switch cafeMachinePumpLever;

    [SerializeField] CafeCup cafeCup;

    [SerializeField] XRSocketInteractor cafeCupSocket;

    [SerializeField] GameObject cafeCupSocketGameObject;
    BoxCollider cafeCupSocketCollider; 

    [SerializeField] XRSocketInteractor sieveSocket;

    [SerializeField] Sieve sieve;

    [SerializeField] GameObject cafeFlowVisualization;

    MeshRenderer cafeFlowVisualizationRenderer;

    [SerializeField] AudioSource brewingSound;

    bool cafeMachineOn;

    bool cafeMachinePumping;

    bool ejectingHotWater;

    public int hotWaterAmount;
    // Start is called before the first frame update
    void Start()
    {
        cafeCupSocketCollider = cafeCupSocketGameObject.GetComponent<BoxCollider>();
        cafeFlowVisualizationRenderer = cafeFlowVisualization.GetComponent<MeshRenderer>();
        cafeFlowVisualizationRenderer.enabled = false;  
        cafeMachineOn = false;
        cafeMachinePumping = false;
        ejectingHotWater = false;
        hotWaterAmount = 0;
        timeIndicator.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        // Debug.Log($"cafeMachineOn = {cafeMachineOn}");
        // Debug.Log($"cafeMachinePumping = {cafeMachinePumping}");

        if (cafeMachineOn != cafeMachineSwitch.switchOn)
        {
            cafeMachineOn = cafeMachineSwitch.switchOn;
        }

        if (cafeMachinePumping != cafeMachinePumpLever.switchOn)
        {
            cafeMachinePumping = cafeMachinePumpLever.switchOn;
        }

        if (cafeMachineOn && cafeMachinePumping)
        {
            cafeFlowVisualizationRenderer.enabled = true;  
            
        }

        if (cafeMachineOn)
        {
            if (cafeMachinePumping)
            {

                if (!ejectingHotWater)
                {
                    ejectingHotWater = true;
                    cafeFlowVisualizationRenderer.enabled = true;
                    if (cafeCupSocket.hasSelection)
                    {
                        cafeCup.GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.GetMask("Untouchable");
                        sieve.GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.GetMask("Untouchable");

                    }
                    StartCoroutine(TimerAmount());
                }

            }
        }

        if (gameManager.gameLevel == 1 && gameManager.tutorialStage == 6 && sieveSocket.hasSelection)
        {
            gameManager.stageStarted = false;
            gameManager.tutorialStage = 7;
        }

        if (gameManager.gameLevel == 1 && gameManager.tutorialStage == 7 && cafeCupSocket.hasSelection)
        {
            gameManager.stageStarted = false;
            gameManager.tutorialStage = 8;
        }
    }

    IEnumerator TimerAmount()
    {
        brewingSound.loop = true;
        brewingSound.Play();
        timeIndicator.text = (0).ToString();
        while (cafeMachineOn && cafeMachinePumping)
        {
            yield return new WaitForSeconds(1f);
            
            timeIndicator.text = ((int.Parse(timeIndicator.text)) + 1).ToString();
            hotWaterAmount++;
            FillCup();
            cafeCup.GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            sieve.GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.GetMask("Untouchable");
        }
        brewingSound.Stop();
        timeIndicator.text = "";
        PassValuesToCup();
        hotWaterAmount = 0;
        cafeCup.GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.GetMask("Cup");
        sieve.GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.GetMask("Sieve");
        cafeFlowVisualizationRenderer.enabled = false;
        ejectingHotWater = false;
        if (gameManager.gameLevel == 1 && gameManager.tutorialStage == 8)
        {
            gameManager.stageStarted = false;
            gameManager.tutorialStage = 9;
        }
    }

    void FillCup()
    {
        if (cafeCupSocket.hasSelection)
        {
            cafeCup.fillAmount++;
        }

    }
    void PassValuesToCup()
    {
        if (cafeCupSocket.hasSelection)
        {
            if (sieveSocket.hasSelection)
            {
                cafeCup.brewWithSieve = true;
            }

            if (sieve.containsCafe)
            {
                cafeCup.sieveContainsCafe = true;
            }
                
            if (sieve.isTampered)
            {
                cafeCup.sieveIsTampered = true;
            }

            cafeCup.cafeGrindDegree = sieve.cafeGrindDegree;
            
        }

    }
}
