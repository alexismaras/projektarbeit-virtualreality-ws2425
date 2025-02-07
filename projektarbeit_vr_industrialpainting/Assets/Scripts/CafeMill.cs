using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class CafeMill : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [SerializeField] GameObject loadingIndicator;
    [SerializeField] Sieve sieve;

    [SerializeField] GameObject sieveGameObject;

    BoxCollider sieveCollider; 
    
    [SerializeField] BoxCollider grindDegreeSwitchCollider;
    [SerializeField] FourWaySwitch grindDegreeSwitch;
    [SerializeField] XRSocketInteractor socketInteractor;
    public int grindDegree = 1;

    bool fillSieve = false;

    // Start is called before the first frame update
    void Start()
    {
        loadingIndicator.SetActive(false);
        sieveCollider = sieveGameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grindDegree != grindDegreeSwitch.switchPos)
        {
            grindDegree = grindDegreeSwitch.switchPos;
        }
        if (gameManager.gameLevel == 1 && gameManager.tutorialStage == 1 && grindDegree == 3)
        {
            gameManager.stageStarted = false;
            gameManager.tutorialStage = 2;
        }

        if (socketInteractor.hasSelection && !fillSieve && !sieve.containsCafe)
        {
            if (gameManager.gameLevel == 1 && gameManager.tutorialStage == 2)
            {
                gameManager.stageStarted = false;
                gameManager.tutorialStage = 3;
            }
            fillSieve = true;
            grindDegreeSwitchCollider.enabled = false;
            sieveCollider.enabled = false;  
            StartCoroutine(FillSieveWithCafe());
        }
    }

    IEnumerator FillSieveWithCafe()
    {
        Debug.Log("Start Filling");
        loadingIndicator.SetActive(true);
        loadingIndicator.GetComponent<Slider>().value = 0;
        for (var i = 0; i < 5; i++)
        {
            loadingIndicator.GetComponent<Slider>().value += 1;
            yield return new WaitForSeconds(1);
        }
        loadingIndicator.SetActive(false);
        sieve.cafeGrindDegree = grindDegree;
        sieve.containsCafe = true;
        grindDegreeSwitchCollider.enabled = true;
        sieveCollider.enabled = true;  
        fillSieve = false;
        Debug.Log("Filled");
        if (gameManager.gameLevel == 1 && gameManager.tutorialStage == 3)
        {
            gameManager.stageStarted = false;
            gameManager.tutorialStage = 4;
        }
    }
}
