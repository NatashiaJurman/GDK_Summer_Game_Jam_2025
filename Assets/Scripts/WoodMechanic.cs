using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodMechanic : MonoBehaviour
{
    public Vector3 woodPosition;
    public Vector3 firePosition;

    public Vector3 woodRotation;

    public GameObject firePrefab;

    private bool woodCanInteract;

    void Start()
    {
        this.transform.position = woodPosition;

        firePrefab.tag = "Untagged";
        
        woodCanInteract = true;
    }

    public void InteractWithWood()
    {
        if (woodCanInteract)
        {
            
            this.transform.position = firePosition + new Vector3(0, -10, 0);
            this.transform.rotation = Quaternion.Euler(woodRotation.x, woodRotation.y, woodRotation.z);
            woodCanInteract = false;
            this.gameObject.tag = "Untagged";
            firePrefab.tag = "Interactable";
        }
    }

    public void InteractWithFire()
    {
        
        this.transform.position = firePosition;
        firePrefab.tag = "Untagged";

    }

}
