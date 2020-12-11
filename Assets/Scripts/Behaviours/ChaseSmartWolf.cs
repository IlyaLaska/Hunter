using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseSmartWolf : AbstractBehaviour
{
    [SerializeField]
    private int chaseDistance;

    private float chaseRadius;
    public List<(GameObject, Rigidbody2D)> chaseList;
    private Animal animal;
    private new void Start()
    {
        base.Start();
        chaseList = new List<(GameObject, Rigidbody2D)>();
        chaseRadius = gameObject.GetComponentsInChildren<CircleCollider2D>()[1].radius;
        animal = GetComponent<Animal>();
    }

    public override Vector3 GetDesiredVelocity()
    {
        var result = Vector3.zero;
        //GameObject chaseHim;
        // float distToChaseHim = 0;
        for (int i = 0; i < chaseList.Count; i++)
        {
            var (objToFlee, objBody) = chaseList[i];
            //check if obj outside of flee range
            if (Vector3.Distance(objToFlee.transform.position, gameObject.transform.position) > (chaseRadius/2 + 1.1f) || !objToFlee.activeInHierarchy)
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
            //if (Vector3.Distance(futurePos, gameObject.transform.position) < chaseDistance)
            //{
            //    result += (futurePos - transform.position);
            //}
            //float futureDist = Vector3.Distance(futurePos, gameObject.transform.position);
            //if (futureDist > distToChaseHim)
            //{
            //    distToChaseHim = futureDist;
            //    result = (futurePos - transform.position);
            //}
            if(i==0) result = (futurePos - transform.position);
        }

        if (chaseList.Count == 0) animal.safeToWander = true;
        return result.normalized * movable.VelocityLimit;
    }
    public override void PrintLine(Vector3 desiredVelocity)
    {
        //Debug.Log(behaviour.GetType() + " V: " + desiredVelocity + " has DVM " + desiredVelocity.magnitude);
        Debug.DrawLine(transform.position, transform.position + desiredVelocity, Color.red);
    }
}
