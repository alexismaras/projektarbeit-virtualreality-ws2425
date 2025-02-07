using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Switch : MonoBehaviour
{
    public bool switchOn = false;

    [SerializeField] GameObject switchPosOff;
    [SerializeField] GameObject switchPosOn;

    [SerializeField] AudioSource switchSound;


    void Start()
    {
        XRGrabInteractable interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnClicked);
    }

    private void OnClicked(SelectEnterEventArgs args)
    {
        switchOn = !switchOn;
        switchSound.Play();
    }

    void Update()
    {
        if (switchOn)
        {
            switchPosOff.GetComponent<MeshRenderer>().enabled = false;
            switchPosOn.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            switchPosOff.GetComponent<MeshRenderer>().enabled = true;
            switchPosOn.GetComponent<MeshRenderer>().enabled = false;
        }

    }   
}
