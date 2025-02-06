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

    [SerializeField] XRGrabInteractable sieveInteractable;
    
    [SerializeField] GameObject grindDegreeSwitch;
    [SerializeField] XRSocketInteractor socketInteractor;

    HingeJoint grindDegreeSwitchJoint;
    public int grindDegree;

    bool fillSieve = false;

    // Start is called before the first frame update
    void Start()
    {
        loadingIndicator.SetActive(false);
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

            if (gameManager.gameLevel == 1 && gameManager.tutorialStage == 1)
            {
                gameManager.tutorialStage = 2;
            }
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
        sieveCollider.enabled = true;  
        fillSieve = false;
        Debug.Log("Filled");
        if (gameManager.gameLevel == 1 && gameManager.tutorialStage == 2)
        {
            gameManager.tutorialStage = 3;
        }
    }
}
