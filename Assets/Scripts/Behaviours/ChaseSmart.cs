using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseSmart : AbstractBehaviour
{
    [SerializeField]
    private Transform objectToChase;
    private Rigidbody2D objectBody;
    [SerializeField]
    private int chaseDistance;
    private new void Start()
    {
        base.Start();
        objectBody = objectToChase.GetComponent<Rigidbody2D>();
    }

    public override Vector3 GetDesiredVelocity()
    {
        float distance = Vector3.Distance(objectToChase.position, gameObject.transform.position);
        float timeToCatch = distance / movable.VelocityLimit;

        Vector2 dist = objectBody.velocity * timeToCatch;
        Vector3 dist3d = new Vector3(dist.x, dist.y, 0);

        Vector3 futurePos = objectToChase.position + dist3d;
        if (Vector3.Distance(futurePos, gameObject.transform.position) < chaseDistance)
        {
            return (futurePos - transform.position).normalized * movable.VelocityLimit;
        }
        else return Vector3.zero;
    }
    public override void PrintLine(Vector3 desiredVelocity)
    {
        return;
    }
}
