using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CafeMachine : MonoBehaviour
{
    [SerializeField] CafeMachineSwitch cafeMachineSwitch;
    [SerializeField] CafeMachineSwitch cafeMachinePumpLever;

    [SerializeField] CafeCup cafeCup;

    [SerializeField] XRSocketInteractor cafeCupSocket;

    [SerializeField] XRSocketInteractor sieveSocket;

    [SerializeField] Sieve sieve;

    bool cafeMachineOn;

    bool cafeMachinePumping;

    bool ejectingHotWater;

    public int hotWaterAmount;
    // Start is called before the first frame update
    void Start()
    {
        cafeMachineOn = false;
        cafeMachinePumping = false;
        hotWaterAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (cafeMachineOn != cafeMachineSwitch.switchOn)
        {
            cafeMachineOn = cafeMachineSwitch.switchOn;
        }

        if (cafeMachinePumping != cafeMachinePumpLever.switchOn)
        {
            cafeMachinePumping = cafeMachinePumpLever.switchOn;
        }

        if (cafeMachineOn && cafeMachinePumping && !ejectingHotWater)
        {
            ejectingHotWater = true;
            StartCoroutine(TimerAmount());
        }
    }

    IEnumerator TimerAmount()
    {
        while (cafeMachineOn && cafeMachinePumping && ejectingHotWater)
        {
            yield return new WaitForSeconds(1f);
            hotWaterAmount++;
        }
        FillCup(hotWaterAmount);
        hotWaterAmount = 0;
    }

    void FillCup(int fillAmount)
    {
        if (cafeCupSocket.hasSelection)
        {
            cafeCup.fillAmount += hotWaterAmount;
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
