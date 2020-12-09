﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : AbstractBehaviour
{
    [SerializeField, Range(0.5f, 5)]
    private float circleDistance = 1;

    [SerializeField, Range(0.5f, 5)]
    private float circleRadius = 2;

    [SerializeField, Range(1, 80)]
    private int angleChangeStep = 15;

    private int angle = 0;

    public override Vector3 GetDesiredVelocity()
    {
        var rnd = Random.value;
        if (rnd < 0.5)
        {
            angle += angleChangeStep;
        }
        else if (rnd < 1)
        {
            angle -= angleChangeStep;
        }

        Vector3 futurePos = movable.transform.position + movable.Velocity.normalized * circleDistance;
        Debug.Log("MTP: " + movable.transform.position);
        Debug.Log("MVN: " + movable.Velocity.normalized * circleDistance);
        Debug.Log("futurePos: " + futurePos + " v: " + futurePos.magnitude);
        Vector3 vector = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * circleRadius;
        Debug.Log("vector: " + vector + " v: " + vector.magnitude);

        return (futurePos + vector - transform.position).normalized * movable.VelocityLimit;
    }
}
