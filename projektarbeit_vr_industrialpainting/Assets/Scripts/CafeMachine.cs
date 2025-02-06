using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class CafeMachine : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [SerializeField] TMP_Text timeIndicator;
    [SerializeField] CafeMachineSwitch cafeMachineSwitch;
    [SerializeField] CafeMachineSwitch cafeMachinePumpLever;

    [SerializeField] CafeCup cafeCup;

    [SerializeField] XRSocketInteractor cafeCupSocket;

    [SerializeField] GameObject cafeCupSocketGameObject;
    BoxCollider cafeCupSocketCollider; 

    [SerializeField] XRSocketInteractor sieveSocket;

    [SerializeField] Sieve sieve;

    [SerializeField] GameObject cafeFlowVisualization;

    MeshRenderer cafeFlowVisualizationRenderer;

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
            cafeCupSocketCollider.enabled = false;
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
                    cafeCupSocketCollider.enabled = false;
                    StartCoroutine(TimerAmount());
                }

            }
        }

        if (gameManager.gameLevel == 1 && gameManager.tutorialStage == 5 && sieveSocket.hasSelection)
        {
            gameManager.tutorialStage = 6;
        }

        if (gameManager.gameLevel == 1 && gameManager.tutorialStage == 6 && cafeCupSocket.hasSelection)
        {
            gameManager.tutorialStage = 7;
        }
    }

    IEnumerator TimerAmount()
    {
        timeIndicator.text = (0).ToString();
        while (cafeMachineOn && cafeMachinePumping)
        {
            yield return new WaitForSeconds(1f);
            timeIndicator.text = ((int.Parse(timeIndicator.text)) + 1).ToString();
            hotWaterAmount++;
            FillCup();
        }
        timeIndicator.text = "";
        PassValuesToCup();
        hotWaterAmount = 0;
        cafeCupSocketCollider.enabled = true;
        cafeFlowVisualizationRenderer.enabled = false;
        ejectingHotWater = false;
        if (gameManager.gameLevel == 1 && gameManager.tutorialStage == 7)
        {
            gameManager.tutorialStage = 8;
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
