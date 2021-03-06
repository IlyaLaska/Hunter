﻿using UnityEngine;

public class Movable : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 acceleration;
    private AbstractBehaviour[] behaviours;

    [SerializeField]
    private float mass = 1;

    [SerializeField, Range(1, 20)]
    private float velocityLimit = 3;

    [SerializeField, Range(1, 500)]
    private float steeringForceLimit = 5;

    private const float Epsilon = 0.05f;

    public float VelocityLimit => velocityLimit;

    public Vector3 Velocity => velocity;

    private float maxV = 0;

    private void Start()
    {
        behaviours = GetComponents<AbstractBehaviour>();
    }

    private void FixedUpdate()
    {
        QueueFriction();
        QueueSteeringForce();
        ApplyQueuedForces();
    }
    public void QueueFriction()
    {
        Vector3 friction = -velocity.normalized * 0.5f;
        QueueForce(friction);
    }
    public void QueueSteeringForce()
    {
        //Steering vector that shows how much you have to deviate from velocity to get DesiredVelocity
        Vector3 steering = Vector3.zero;

        foreach (AbstractBehaviour behaviour in behaviours)
        {
            Vector3 desiredVelocity = behaviour.GetDesiredVelocity() * behaviour.Weight;

            behaviour.PrintLine(desiredVelocity/2);
            if (desiredVelocity != Vector3.zero) steering += desiredVelocity - velocity;
        }
        // Debug.Log("Steer: " + " V: " + Vector3.ClampMagnitude(steering - velocity, steeringForceLimit) + " has DVM " + Vector3.ClampMagnitude(steering - velocity, steeringForceLimit).magnitude);
        QueueForce(Vector3.ClampMagnitude(steering - velocity, steeringForceLimit));
    }
    void ApplyQueuedForces()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        velocity = Vector3.ClampMagnitude(velocity, velocityLimit);

        if (velocity.magnitude < Epsilon)
        {
            velocity = Vector3.zero;
            return;
        }
        if (velocity.magnitude > maxV)
        {
            maxV = velocity.magnitude;
        }
        transform.position += velocity * Time.fixedDeltaTime;
        acceleration = Vector3.zero;

        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    public void QueueForce(Vector3 force)
    {
        acceleration += (force/mass);
        Debug.DrawLine(transform.position, transform.position + acceleration, Color.white);

    }
}