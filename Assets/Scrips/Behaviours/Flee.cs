using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : AbstractBehaviour
{
    [SerializeField]
    private Transform objectToFlee;
    [SerializeField]
    private int fleeDistance;

    public override Vector3 GetDesiredVelocity()
    {
        if (Vector3.Distance(objectToFlee.position, gameObject.transform.position) < fleeDistance)
        {
            return -(objectToFlee.position - transform.position).normalized * movable.VelocityLimit;
        }
        else return Vector3.zero;
    }
}
