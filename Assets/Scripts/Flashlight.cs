using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject ON;
    public GameObject OFF;
    public GameObject ONBULB;
    public GameObject OFFBULB;

    public GameObject newParent;

    private bool isOn;
    private bool isEquipped;

    public void Interact()
    {
        this.transform.SetParent(newParent.transform, true);

        this.transform.position = new Vector3(newParent.transform.position.x, newParent.transform.position.y, newParent.transform.position.z);

        this.transform.rotation = newParent.transform.rotation;
        
        this.GetComponent<MeshRenderer>().enabled = false;
        ONBULB.GetComponent<MeshRenderer>().enabled = false;
        OFFBULB.GetComponent<MeshRenderer>().enabled = false;

        isEquipped = true;
    }

    void Start()
    {
        isEquipped = false;

        ON.SetActive(true);
        OFF.SetActive(false);
        isOn = true;
    }


    void Update()
    {
        if (isEquipped)
        {
            FlashlightToggle();
        }
    }

    public void FlashlightToggle()
    {


        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isOn)
            {
                ON.SetActive(false);
                OFF.SetActive(true);
            }
            else if (!isOn)
            {
                ON.SetActive(true);
                OFF.SetActive(false);
            }

            isOn = !isOn;
        }
    }
}
