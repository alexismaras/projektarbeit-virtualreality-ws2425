using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    public int gameLevel;
    public int tutorialStage = 0;

    public int examStage = 0;

    public bool stageStarted = false;

    [SerializeField] UiManager uiManager;

    [SerializeField] GameObject cafeCupGameObject;
    CafeCup cafeCup;
    XRGrabInteractable cafeCupInteractor;
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
    XRGrabInteractable sieveInteractor;
    BoxCollider sieveCollider;

    [SerializeField] GameObject tamperToolGameObject;
    XRGrabInteractable tamperToolInteractor;    
    BoxCollider tamperToolCollider;
    // Start is called before the first frame update
    void Start()
    {

        cafeCup = cafeCupGameObject.GetComponent<CafeCup>();
        cafeCupInteractor = cafeCup.GetComponent<XRGrabInteractable>();
        cafeCupCollider = cafeCupGameObject.GetComponent<BoxCollider>();

        sieve = sieveGameObject.GetComponent<Sieve>();
        sieveInteractor = sieve.GetComponent<XRGrabInteractable>();
        sieveCollider = sieveGameObject.GetComponent<BoxCollider>();

        tamperToolCollider = tamperToolGameObject.GetComponent<BoxCollider>();
        tamperToolInteractor = tamperToolGameObject.GetComponent<XRGrabInteractable>();

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
            Exam();
        }
        
    }

    void Tutorial()
    {
        if (tutorialStage == 0 && !stageStarted) //UI Press Yes
        {
            stageStarted = true;
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = false;
            sieveInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            tamperToolInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            cafeCupInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");

            uiManager.ShowIntroScreen();

        }
        else if (tutorialStage == 1 && !stageStarted) //GrindDegree to 3
        {
            stageStarted = true;
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = true;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = false;
            sieveInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            tamperToolInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            cafeCupInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");

            uiManager.ShowTutorialScreen1();

        }
        else if (tutorialStage == 2 && !stageStarted) //Put Sieve from Tamperstation inside Grinder
        {
            stageStarted = true;
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = true;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = false;
            sieveInteractor.interactionLayers = InteractionLayerMask.GetMask("Sieve");
            tamperToolInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            cafeCupInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");

            uiManager.ShowTutorialScreen2();
        }
        else if (tutorialStage == 3 && !stageStarted) //Wait for Grinder
        {
            stageStarted = true;
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = false;
            sieveInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            tamperToolInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            cafeCupInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
        }

        else if (tutorialStage == 4 && !stageStarted) //Put Sieve back to Tamperstation
        {
            stageStarted = true;
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = false;
            sieveInteractor.interactionLayers = InteractionLayerMask.GetMask("Sieve");
            tamperToolInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            cafeCupInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");

            uiManager.ShowTutorialScreen3();
        }
        else if (tutorialStage == 5 && !stageStarted) //Tamper the Sieve and Put Tamper back
        {
            stageStarted = true;
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = false;
            sieveInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            tamperToolInteractor.interactionLayers = InteractionLayerMask.GetMask("Tamper");
            cafeCupInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");

            uiManager.ShowTutorialScreen4();
        }

        else if (tutorialStage == 6 && !stageStarted) //Sieve Inside CafeMachine
        {
            stageStarted = true;
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = true;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = false;
            sieveInteractor.interactionLayers = InteractionLayerMask.GetMask("Sieve");
            tamperToolInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            cafeCupInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");


            uiManager.ShowTutorialScreen5();
        }

        else if (tutorialStage == 7 && !stageStarted) //Put Cup Under
        {
            stageStarted = true;
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = true;
            outputAreaSocketCollider.enabled = false;
            sieveInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            tamperToolInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            cafeCupInteractor.interactionLayers = InteractionLayerMask.GetMask("Cup");

            uiManager.ShowTutorialScreen6();
        }

        else if (tutorialStage == 8 && !stageStarted) //Pull Lever of Cafe Machine
        {
            stageStarted = true;
            cafeMachinePumpLeverCollider.enabled = true;
            cafeMachineSwitchCollider.enabled = true;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = false;
            sieveInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            tamperToolInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            cafeCupInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");

            uiManager.ShowTutorialScreen7();
        }

        else if (tutorialStage == 9 && !stageStarted) //Put Cafe in Output Area
        {
            stageStarted = true;
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = true;
            sieveInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            tamperToolInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            cafeCupInteractor.interactionLayers = InteractionLayerMask.GetMask("Cup");

            uiManager.ShowTutorialScreen8();
        }

        else if (tutorialStage == 10 && !stageStarted) //Result
        {
            stageStarted = true;
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = false;
            sieveInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            tamperToolInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            cafeCupInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");

            uiManager.ShowTutorialScreen9();
        }

    }

    void Exam()
    {
        if (examStage == 0 && !stageStarted) //UI Press Yes
        {
            stageStarted = true;
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = false;
            sieveInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            tamperToolInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            cafeCupInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");

            uiManager.ShowExamIntroScreen();

        }

        if (examStage == 1 && !stageStarted) //Do your thing
        {
            stageStarted = true;
            cafeMachinePumpLeverCollider.enabled = true;
            cafeMachineSwitchCollider.enabled = true;
            grindDegreeSwitchCollider.enabled = true;
            cafeMillSocketCollider.enabled = true;
            cafeMachineSieveSocketCollider.enabled = true;
            cafeMachineCupSocketCollider.enabled = true;
            outputAreaSocketCollider.enabled = true;
            sieveInteractor.interactionLayers = InteractionLayerMask.GetMask("Sieve");
            tamperToolInteractor.interactionLayers = InteractionLayerMask.GetMask("Tamper");
            cafeCupInteractor.interactionLayers = InteractionLayerMask.GetMask("Cup");

            uiManager.HideUiCanvas();

        }

        if (examStage == 2 && !stageStarted) //Result
        {
            stageStarted = true;
            cafeMachinePumpLeverCollider.enabled = false;
            cafeMachineSwitchCollider.enabled = false;
            grindDegreeSwitchCollider.enabled = false;
            cafeMillSocketCollider.enabled = false;
            cafeMachineSieveSocketCollider.enabled = false;
            cafeMachineCupSocketCollider.enabled = false;
            outputAreaSocketCollider.enabled = true;
            sieveInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            tamperToolInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");
            cafeCupInteractor.interactionLayers = InteractionLayerMask.GetMask("Untouchable");

            uiManager.ShowExamResultScreen();

            uiManager.ShowUiCanvas();

        }

    }
}
