using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FourWaySwitch : MonoBehaviour
{
    public int switchPos = 1;

    [SerializeField] GameObject switchPos1;
    [SerializeField] GameObject switchPos2;

    [SerializeField] GameObject switchPos3;
    [SerializeField] GameObject switchPos4;


    void Start()
    {
        XRGrabInteractable interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnClicked);
    }

    private void OnClicked(SelectEnterEventArgs args)
    {   
        if (switchPos < 4)
        {
            switchPos += 1;
        }
        else
        {
            switchPos = 1;
        }
        
    }

    void Update()
    {
        if (switchPos == 1)
        {
            switchPos1.GetComponent<MeshRenderer>().enabled = true;
            switchPos2.GetComponent<MeshRenderer>().enabled = false;
            switchPos3.GetComponent<MeshRenderer>().enabled = false;
            switchPos4.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (switchPos == 2)
        {
            switchPos1.GetComponent<MeshRenderer>().enabled = false;
            switchPos2.GetComponent<MeshRenderer>().enabled = true;
            switchPos3.GetComponent<MeshRenderer>().enabled = false;
            switchPos4.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (switchPos == 3)
        {
            switchPos1.GetComponent<MeshRenderer>().enabled = false;
            switchPos2.GetComponent<MeshRenderer>().enabled = false;
            switchPos3.GetComponent<MeshRenderer>().enabled = true;
            switchPos4.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (switchPos == 4)
        {
            switchPos1.GetComponent<MeshRenderer>().enabled = false;
            switchPos2.GetComponent<MeshRenderer>().enabled = false;
            switchPos3.GetComponent<MeshRenderer>().enabled = false;
            switchPos4.GetComponent<MeshRenderer>().enabled = true;
        }

    }   
}
