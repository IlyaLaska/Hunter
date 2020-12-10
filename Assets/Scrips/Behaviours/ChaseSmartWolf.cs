using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseSmartWolf : AbstractBehaviour
{
    //[SerializeField]
    //private Transform objectToFlee;
    //private Rigidbody2D objectBody;
    [SerializeField]
    private int chaseDistance;

    //private Hare[] hares;
    //private Doe[] does;
    //private Wolf[] wolves;
    //private GameObject hunter;
    public List<(GameObject, Rigidbody2D)> chaseList;
    private Animal animal;
    private new void Start()
    {
        base.Start();
        chaseList = new List<(GameObject, Rigidbody2D)>();
        animal = GetComponent<Animal>();
    }

    public override Vector3 GetDesiredVelocity()
    {
        var result = Vector3.zero;
        for (int i = 0; i < chaseList.Count; i++)
        {
            var (objToFlee, objBody) = chaseList[i];
            //check if obj outside of flee range
            if (Vector3.Distance(objToFlee.transform.position, gameObject.transform.position) > chaseDistance || !objToFlee.activeInHierarchy)
            {
                //Debug.Log(objToFlee.name + " moved too far");
                chaseList.RemoveAt(i);
                i--;
                continue;
            }
            float distance = Vector3.Distance(objToFlee.transform.position, gameObject.transform.position);
            float timeToCatch = distance / movable.VelocityLimit;

            Vector2 dist = objBody.velocity * timeToCatch;
            Vector3 dist3d = new Vector3(dist.x, dist.y, 0);

            Vector3 futurePos = objToFlee.transform.position + dist3d;
            if (Vector3.Distance(futurePos, gameObject.transform.position) < chaseDistance)
            {
                result += (futurePos - transform.position).normalized * movable.VelocityLimit;
            }
        }
        if (chaseList.Count == 0) animal.safeToWander = true;
        return result;
    }
    public override void PrintLine(Vector3 desiredVelocity)
    {
        //Debug.Log(behaviour.GetType() + " V: " + desiredVelocity + " has DVM " + desiredVelocity.magnitude);
        Debug.DrawLine(transform.position, transform.position + desiredVelocity, Color.red);
    }
}
