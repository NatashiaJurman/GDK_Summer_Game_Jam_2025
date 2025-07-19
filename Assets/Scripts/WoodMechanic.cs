using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodMechanic : MonoBehaviour
{
    public Vector3 woodPosition;
    
    public Vector3 firePosition;
    public float fireRotation;

    private bool woodCanInteract;
    private bool fireCanInteract;

    public GameObject campfire;


    void Start()
    {
        this.transform.position = woodPosition;

        woodCanInteract = true;
        fireCanInteract = false;

        campfire.gameObject.tag = "Untagged";
    }

    public void WoodInteraction()
    {
        if (woodCanInteract)
        {
            woodPosition = firePosition + new Vector3(0, 100, 0);
            this.transform.position = woodPosition;
            this.transform.rotation = Quaternion.Euler(0, 0, fireRotation);

            woodCanInteract = false;
            this.gameObject.tag = "Untagged";

            fireCanInteract = true;
            campfire.gameObject.tag = "Interactable";
        }     
    }

    public void PlaceWood()
    {
        if (fireCanInteract)
        {
            this.transform.position = woodPosition - new Vector3(0, 100, 0);

            campfire.gameObject.tag = "Untagged";
        }
        
    }
}
