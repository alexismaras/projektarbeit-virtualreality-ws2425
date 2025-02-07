using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeCup : MonoBehaviour
{
    [SerializeField] MeshRenderer caffeeVisual1;
    [SerializeField] MeshRenderer caffeeVisual2;
    [SerializeField] MeshRenderer caffeeVisual3;
    [SerializeField] MeshRenderer caffeeVisual4;

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
        if (fillAmount <= 2)
        {
            caffeeVisual1.enabled = false;
            caffeeVisual2.enabled = false;
            caffeeVisual3.enabled = false;
            caffeeVisual4.enabled = false;
        }

        if (fillAmount > 2 && fillAmount <= 10)
        {  
            caffeeVisual1.enabled = true;
            caffeeVisual2.enabled = false;
            caffeeVisual3.enabled = false;
            caffeeVisual4.enabled = false;
        }

        if (fillAmount > 10 && fillAmount <= 18)
        {
            caffeeVisual1.enabled = false;
            caffeeVisual2.enabled = true;
            caffeeVisual3.enabled = false;
            caffeeVisual4.enabled = false;
        }

        if (fillAmount > 18 && fillAmount <= 26)
        {
            caffeeVisual1.enabled = false;
            caffeeVisual2.enabled = false;
            caffeeVisual3.enabled = true;
            caffeeVisual4.enabled = false;
        }

        if (fillAmount > 26)
        {
            caffeeVisual1.enabled = false;
            caffeeVisual2.enabled = false;
            caffeeVisual3.enabled = true;
            caffeeVisual4.enabled = false;
        }
        
    }
}
