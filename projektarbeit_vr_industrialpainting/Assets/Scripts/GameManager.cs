using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    public int gameLevel;
    public int tutorialStage = 0;

    [SerializeField] UiManager uiManager;

    [SerializeField] GameObject cafeCupGameObject;
    CafeCup cafeCup;
    BoxCollider cafeCupCollider;

    [SerializeField] GameObject grindDegreeSwitchGameObject;
    BoxCollider grindDegreeSwitchCollider;

    [SerializeField] GameObject cafeMillSocketGameObject;
    XRSocketInteractor cafeMillSocketInteractor;
    BoxCollider cafeMillSocketCollider;

    [SerializeField] GameObject cafeMachineSieveSocketGameObject;
    XRSocketInteractor cafeMachineSieveSocketInteractor;
    BoxCollider cafeMachineSieveSocketCollider;

    [SerializeField] GameObject cafeMachineCupSocketGameObject;
    XRSocketInteractor cafeMachineCupSocketInteractor;
    BoxCollider cafeMachineCupSocketCollider;

    [SerializeField] GameObject cafeMachineSwitchGameObject;
    BoxCollider cafeMachineSwitchCollider;

    [SerializeField] GameObject cafeMachinePumpLeverGameObject;
    BoxCollider cafeMachinePumpLeverCollider;

    [SerializeField] GameObject outputAreaSocketGameObject;
    XRSocketInteractor outputAreaSocketInteractor;
    BoxCollider outputAreaSocketCollider;
    

    [SerializeField] GameObject sieveGameObject;
    Sieve sieve;
    BoxCollider sieveCollider;

    [SerializeField] GameObject tamperToolGameObject;
    BoxCollider tamperToolCollider;
    // Start is called before the first frame update
    void Start()
    {
        cafeCup = cafeCupGameObject.GetComponent<CafeCup>();
        cafeCupCollider = cafeCupGameObject.GetComponent<BoxCollider>();

        sieve = sieveGameObject.GetComponent<Sieve>();
        sieveCollider = sieveGameObject.GetComponent<BoxCollider>();

        tamperToolCollider = tamperToolGameObject.GetComponent<BoxCollider>();

        grindDegreeSwitchCollider = grindDegreeSwitchGameObject.GetComponent<BoxCollider>();

        cafeMillSocketCollider = cafeMillSocketGameObject.GetComponent<BoxCollider>();
        cafeMillSocketInteractor = cafeMillSocketGameObject.GetComponent<XRSocketInteractor>();

        cafeMachineSieveSocketCollider = cafeMachineSieveSocketGameObject.GetComponent<BoxCollider>();
        cafeMachineSieveSocketInteractor = cafeMachineSieveSocketGameObject.GetComponent<XRSocketInteractor>();

        cafeMachineCupSocketCollider = cafeMachineCupSocketGameObject.GetComponent<BoxCollider>();
        cafeMachineCupSocketInteractor = cafeMachineCupSocketGameObject.GetComponent<XRSocketInteractor>();

        cafeMachinePumpLeverCollider = cafeMachinePumpLeverGameObject.GetComponent<BoxCollider>();

        cafeMachineSwitchCollider = cafeMachineSwitchGameObject.GetComponent<BoxCollider>();

        outputAreaSocketCollider = outputAreaSocketGameObject.GetComponent<BoxCollider>();
        outputAreaSocketInteractor = outputAreaSocketGameObject.GetComponent<XRSocketInteractor>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameLevel == 1)
        {
            Tutorial();
        }
        else if (gameLevel == 2)
        {
            Practice();
        }
        else if (gameLevel == 3)
        {
            Exam();
        }
        
    }

    void Tutorial()
    {
        if (tutorialStage == 0) //UI Press Yes
        {
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = false;
            sieveCollider.enabled = false;
            tamperToolCollider.enabled = false;
            // cafeCupCollider.enabled = false;

            uiManager.ShowIntroScreen();

        }
        else if (tutorialStage == 1) //GrindDegree to 3
        {
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = true;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = false;
            sieveCollider.enabled = false;
            tamperToolCollider.enabled = false;
            // cafeCupCollider.enabled = false;

            uiManager.ShowTutorialScreen1();

        }
        else if (tutorialStage == 2) //Put Sieve from Tamperstation inside Grinder
        {
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = true;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = false;
            sieveCollider.enabled = true;
            tamperToolCollider.enabled = false;
            // cafeCupCollider.enabled = false;

            uiManager.ShowTutorialScreen2();
        }
        else if (tutorialStage == 3) //Put Sieve back to Tamperstation
        {
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = false;
            sieveCollider.enabled = true;
            tamperToolCollider.enabled = false;
            // cafeCupCollider.enabled = false;

            uiManager.ShowTutorialScreen3();
        }
        else if (tutorialStage == 4) //Tamper the Sieve and Put Tamper back
        {
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = false;
            sieveCollider.enabled = false;
            tamperToolCollider.enabled = true;
            // cafeCupCollider.enabled = false;

            uiManager.ShowTutorialScreen4();
        }

        else if (tutorialStage == 5) //Sieve Inside CafeMachine
        {
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = true;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = false;
            sieveCollider.enabled = true;
            tamperToolCollider.enabled = false;
            // cafeCupCollider.enabled = false;

            uiManager.ShowTutorialScreen5();
        }

        else if (tutorialStage == 6) //Put Cup Under
        {
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = true;
            outputAreaSocketCollider.enabled = false;
            sieveCollider.enabled = false;
            tamperToolCollider.enabled = false;
            // cafeCupCollider.enabled = true;

            uiManager.ShowTutorialScreen6();
        }

        else if (tutorialStage == 7) //Pull Lever of Cafe Machine
        {
            cafeMachinePumpLeverCollider.enabled = true;
            cafeMachineSwitchCollider.enabled = true;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = false;
            sieveCollider.enabled = false;
            tamperToolCollider.enabled = false;
            // cafeCupCollider.enabled = false;

            uiManager.ShowTutorialScreen7();
        }

        else if (tutorialStage == 8) //Put Cafe in Output Area
        {
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = true;
            sieveCollider.enabled = false;
            tamperToolCollider.enabled = false;
            // cafeCupCollider.enabled = false;

            uiManager.ShowTutorialScreen8();
        }

        else if (tutorialStage == 9) //Result
        {
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = false;
            sieveCollider.enabled = false;
            tamperToolCollider.enabled = false;
            // cafeCupCollider.enabled = false;

            uiManager.ShowTutorialScreen9();
        }

    }

    void Practice()
    {

    }

    void Exam()
    {

    }

    // void LockAll()
    // {

    // }

    // void UnlockAll()
    // {

    // }
}
