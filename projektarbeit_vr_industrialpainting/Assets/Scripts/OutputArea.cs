using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OutputArea : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject cafeCupSocketGameObject;
    BoxCollider cafeCupSocketCollider;
    [SerializeField] XRSocketInteractor cafeCupSocket;

    [SerializeField] GameObject cafeCupGameObject;
    BoxCollider cafeCupCollider;
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
        cafeCupSocketCollider = cafeCupSocketGameObject.GetComponent<BoxCollider>();
        cafeCupCollider = cafeCupGameObject.GetComponent<BoxCollider>();
        cafeServed = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (!cafeServed && cafeCupSocket.hasSelection)
        {
            cafeServed = true;
            cafeCupSocketCollider.enabled = false;
            cafeCupCollider.enabled = false;
            fillAmount = cafeCup.fillAmount;
            brewWithSieve = cafeCup.brewWithSieve;
            sieveContainsCafe = cafeCup.sieveContainsCafe;
            sieveIsTampered = cafeCup.sieveIsTampered;
            cafeGrindDegree = cafeCup.cafeGrindDegree;

            if (gameManager.gameLevel == 1 && gameManager.tutorialStage == 8)
            {
                gameManager.tutorialStage = 9;
            }
        }
    }   
}
