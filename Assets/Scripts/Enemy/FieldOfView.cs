using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;

    [Range(0, 360)]
    public float angle;

    public GameObject hidingSpot;

    public LayerMask targetMask;

    public bool canSeeHidingSpot;

    public void BeginChecking()
    {
        hidingSpot = GameObject.FindGameObjectWithTag("HidingSpot");

        FieldOfViewCheck();
    }

    public void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            for (int i = 0; i < rangeChecks.Length; i++)
            {
                Transform target = rangeChecks[i].transform;
                Vector3 directionToTarget = (target.position - transform.position).normalized;

                if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2) 
                { 
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);

                    if(Physics.Raycast(transform.position, directionToTarget, distanceToTarget, targetMask))
                    {
                        canSeeHidingSpot = true;

                        this.transform.position = rangeChecks[0].transform.position + new Vector3(0, 1, 0);

                        Debug.Log("Can see hiding spot");
                    }
                    else
                    {
                        canSeeHidingSpot = false;
                    }
                }
                else
                {
                    canSeeHidingSpot = false;
                }
                
                    
                
            }

        }
        else if (canSeeHidingSpot)
        {
            canSeeHidingSpot = false;
        }
    }
}
