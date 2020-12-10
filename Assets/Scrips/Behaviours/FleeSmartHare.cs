using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeSmartHare : AbstractBehaviour
{
    [SerializeField]
    private int fleeDistance;

    public List<(GameObject, Rigidbody2D)> fleeFrom;
    private Animal animal;
    private float fleeRadius;
    private new void Start()
    {
        base.Start();
        fleeFrom = new List<(GameObject, Rigidbody2D)>();
        fleeRadius = gameObject.GetComponentsInChildren<CircleCollider2D>()[1].radius;
        animal = GetComponent<Animal>();
    }

    public override Vector3 GetDesiredVelocity()
    {
        var result = Vector3.zero;
        //Debug.Log("fleeFrom Len: " + fleeFrom.Count);
        for (int i = 0; i < fleeFrom.Count; i++)
        {
            var (objToFlee, objBody) = fleeFrom[i];
            //check if obj outside of flee range
            if (Vector3.Distance(objToFlee.transform.position, gameObject.transform.position) > fleeRadius || !objToFlee.activeInHierarchy)
            {
                Debug.Log(objToFlee.name + " moved too far");
                fleeFrom.RemoveAt(i);
                i--;
                continue;
            }
            result += -(objToFlee.transform.position - transform.position).normalized * movable.VelocityLimit;//From dumb flee
        }
        //Debug.Log("Res: " + result.magnitude);
        if (fleeFrom.Count == 0) animal.safeToWander = true;
        return result.normalized * movable.VelocityLimit;
    }
    public override void PrintLine(Vector3 desiredVelocity)
    {
        //Debug.Log(behaviour.GetType() + " V: " + desiredVelocity + " has DVM " + desiredVelocity.magnitude);
        Debug.DrawLine(transform.position, transform.position + desiredVelocity, Color.green);
    }
}
