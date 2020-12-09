using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AvoidCliffs : AbstractBehaviour
{
    private float edgeX = 40f;
    private float edgeY = 18f;

    public override Vector3 GetDesiredVelocity()
    {
        var cam = Camera.main;
        var maxSpeed = movable.VelocityLimit;
        var v = movable.Velocity;
        if (cam == null)
        {
            return Vector3.zero;
        }
        
        if (transform.position.x >= edgeX)
        {
            return new Vector3(-maxSpeed, 0, 0);

        }
        if (transform.position.x <= -edgeX)
        {
            //Debug.Log("RUN");
            return new Vector3(maxSpeed, 0, 0);
        }
        if (transform.position.y >= edgeY)
        {
            return new Vector3(0, -maxSpeed, 0);
        }
        if (transform.position.y <= -edgeY)
        {
            return new Vector3(0, maxSpeed, 0);
        }

        return Vector3.zero;
    }
}