using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeSmartHare : AbstractBehaviour
{
    //[SerializeField]
    //private Transform objectToFlee;
    //private Rigidbody2D objectBody;
    [SerializeField]
    private int fleeDistance;

    //private Hare[] hares;
    //private Doe[] does;
    //private Wolf[] wolves;
    //private GameObject hunter;
    public List<(GameObject, Rigidbody2D)> fleeFrom;
    private Animal animal;
    private new void Start()
    {
        base.Start();
        //objectBody = objectToFlee.GetComponent<Rigidbody2D>();
        fleeFrom = new List<(GameObject, Rigidbody2D)>();
        animal = GetComponent<Animal>();
        //hares = Resources.FindObjectsOfTypeAll<Hare>();
        //hares = Resources.FindObjectsOfTypeAll<Hare>();
        //hares = Resources.FindObjectsOfTypeAll<Hare>();
        //hunter = GM.instance.Hunter;
    }

    public override Vector3 GetDesiredVelocity()
    {
        //foreach (var (objToFlee, objBody) in fleeFrom)
        //{

        //}
        var result = Vector3.zero;
        //Debug.Log("fleeFrom Len: " + fleeFrom.Count);
        for (int i = 0; i < fleeFrom.Count; i++)
        {
            var (objToFlee, objBody) = fleeFrom[i];
            //check if obj outside of flee range
            if (Vector3.Distance(objToFlee.transform.position, gameObject.transform.position) > fleeDistance || !objToFlee.activeInHierarchy)
            {
                //Debug.Log(objToFlee.name + " moved too far");
                fleeFrom.RemoveAt(i);
                i--;
                continue;
            }
            //float distance = Vector3.Distance(objToFlee.transform.position, gameObject.transform.position);
            //float timeToCatch = distance / movable.VelocityLimit;

            //Vector2 dist = objBody.velocity * timeToCatch;
            //Vector3 dist3d = new Vector3(dist.x, dist.y, 0);

            //Vector3 futurePos = objToFlee.transform.position + dist3d;
            //if (Vector3.Distance(futurePos, gameObject.transform.position) < fleeDistance)
            //{
            //result += -(futurePos - transform.position).normalized * movable.VelocityLimit;
                                    result += -(objToFlee.transform.position - transform.position).normalized * movable.VelocityLimit;//From dumb flee
            //}
        }
        //Debug.Log("Res: " + result.magnitude);
        if (fleeFrom.Count == 0) animal.safeToWander = true;
        return result;
    }
    public override void PrintLine(Vector3 desiredVelocity)
    {
        //Debug.Log(behaviour.GetType() + " V: " + desiredVelocity + " has DVM " + desiredVelocity.magnitude);
        Debug.DrawLine(transform.position, transform.position + desiredVelocity, Color.green);
    }
}
