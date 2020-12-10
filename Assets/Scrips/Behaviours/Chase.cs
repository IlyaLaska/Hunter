using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : AbstractBehaviour
{
    [SerializeField]
    private Transform objectToChase;
    [SerializeField]
    private int chaseDistance;

    public override Vector3 GetDesiredVelocity()
    {
        if (Vector3.Distance(objectToChase.position, gameObject.transform.position) < chaseDistance)
        {
            return (objectToChase.position - transform.position).normalized * movable.VelocityLimit;
        }
        else return Vector3.zero;
    }

    public override void PrintLine(Vector3 desiredVelocity)
    {
        return;
    }
}
