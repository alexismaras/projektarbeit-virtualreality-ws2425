using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OutputArea : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] XRSocketInteractor cafeCupSocket;
    [SerializeField] CafeCup cafeCup;
    public int fillAmount;
    public bool brewWithSieve;
    public bool sieveContainsCafe;
    public bool sieveIsTampered;
    public int cafeGrindDegree;

    public bool cafeServed;
    // Start is called before the first frame update
    void Start()
    {
        cafeServed = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (!cafeServed && cafeCupSocket.hasSelection)
        {
            cafeServed = true;
            fillAmount = cafeCup.fillAmount;
            brewWithSieve = cafeCup.brewWithSieve;
            sieveContainsCafe = cafeCup.sieveContainsCafe;
            sieveIsTampered = cafeCup.sieveIsTampered;
            cafeGrindDegree = cafeCup.cafeGrindDegree;

            if (gameManager.gameLevel == 1 && gameManager.tutorialStage == 9)
            {
                gameManager.stageStarted = false;
                gameManager.tutorialStage = 10;
            }

            if (gameManager.gameLevel == 2 && gameManager.examStage == 1)
            {
                gameManager.stageStarted = false;
                gameManager.examStage = 2;
            }
        }
    }   
}
