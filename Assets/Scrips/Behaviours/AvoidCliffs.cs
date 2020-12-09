using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AvoidCliffs : AbstractBehaviour
{
    private float edgeX = 40f;
    private float edgeY = 19f;

    public override Vector3 GetDesiredVelocity()
    {
        var maxSpeed = movable.VelocityLimit;

        float rnd = Random.Range(-maxSpeed, maxSpeed);
        if (transform.position.x >= edgeX)
        {
            //Debug.Log("RUN: " + new Vector3(-maxSpeed, 0, 0));
            return new Vector3(-maxSpeed, rnd, 0).normalized * maxSpeed;

        }
        if (transform.position.x <= -edgeX)
        {
            //Debug.Log("RUN");
            return new Vector3(maxSpeed, rnd, 0).normalized * maxSpeed;
        }
        if (transform.position.y >= edgeY)
        {
            return new Vector3(rnd, -maxSpeed, 0).normalized * maxSpeed;
        }
        if (transform.position.y <= -edgeY)
        {
            return new Vector3(rnd, maxSpeed, 0).normalized * maxSpeed;
        }

        return Vector3.zero;
    }
}