using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeCup : MonoBehaviour
{
    public int fillAmount;
    public bool brewWithSieve;
    public bool sieveContainsCafe;
    public bool sieveIsTampered;
    public int cafeGrindDegree;
    // Start is called before the first frame update
    void Start()
    {
        fillAmount = 0;
        brewWithSieve = false;
        sieveContainsCafe = false;
        sieveIsTampered = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
