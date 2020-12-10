using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AvoidCliffs : AbstractBehaviour
{
    [SerializeField, Range(15, 40)]
    private float edgeX = 40f;
    [SerializeField, Range(5, 19)]
    private float edgeY = 19f;

    public override Vector3 GetDesiredVelocity()
    {
        var maxSpeed = movable.VelocityLimit;

        int signX;
        int signY;
        //if((int))
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

      public override void PrintLine(Vector3 desiredVelocity)
      {
            // Debug.Log(GetType() + " V: " + desiredVelocity + " has DVM " + desiredVelocity.magnitude);
            Debug.DrawLine(transform.position, transform.position + desiredVelocity, Color.black);
      }
}