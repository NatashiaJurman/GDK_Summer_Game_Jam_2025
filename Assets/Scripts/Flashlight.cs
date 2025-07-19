using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject ON;
    public GameObject OFF;

    public GameObject newParent;

    private bool isOn;
    private bool isEquipped;

    public void Interact()
    {
        this.transform.SetParent(newParent.transform, true);

        this.transform.position = new Vector3(newParent.transform.position.x + 0.6f, newParent.transform.position.y - 0.75f, newParent.transform.position.z - 0.2f);

        this.transform.rotation = newParent.transform.rotation;
        transform.Rotate(90, 0, 0);

        isEquipped = true;
    }

    void Start()
    {
        isEquipped = true;

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
