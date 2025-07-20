using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WoodMechanic : MonoBehaviour
{
    public Vector3 woodPosition;
    public Vector3 firePosition;

    public Vector3 woodRotation;

    public GameObject firePrefab;
    public GameObject nextSparrow;

    private bool woodCanInteract;

    



    void Start()
    {
        
        

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
        if (this.transform.position == firePosition + new Vector3(0, -10, 0))
        {
            this.transform.position = woodPosition;
            
            
        }
        
        nextSparrow.tag = "Interactable";
        firePrefab.tag = "Untagged";

    }

}
