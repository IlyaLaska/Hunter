using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeSmartHare : AbstractBehaviour
{
    [SerializeField]
    private Transform objectToFlee;
    private Rigidbody2D objectBody;
    [SerializeField]
    private int fleeDistance;

    private Hare[] hares;
    private Doe[] does;
    private Wolf[] wolves;
    private GameObject hunter;
    private new void Start()
    {
        base.Start();
        objectBody = objectToFlee.GetComponent<Rigidbody2D>();
        hares = Resources.FindObjectsOfTypeAll<Hare>();
        hares = Resources.FindObjectsOfTypeAll<Hare>();
        hares = Resources.FindObjectsOfTypeAll<Hare>();
        hunter = GM.instance.Hunter;
    }

    public override Vector3 GetDesiredVelocity()
    {
        float distance = Vector3.Distance(objectToFlee.position, gameObject.transform.position);
        float timeToCatch = distance / movable.VelocityLimit;

        Vector2 dist = objectBody.velocity * timeToCatch;
        Vector3 dist3d = new Vector3(dist.x, dist.y, 0);

        Vector3 futurePos = objectToFlee.position + dist3d;
        if (Vector3.Distance(futurePos, gameObject.transform.position) < fleeDistance)
        {
            return -(futurePos - transform.position).normalized * movable.VelocityLimit;
        }
        else return Vector3.zero;
    }
}
