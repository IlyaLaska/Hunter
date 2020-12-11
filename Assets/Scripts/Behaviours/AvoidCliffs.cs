using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AvoidCliffs : AbstractBehaviour
{
    [SerializeField, Range(15, 40)]
    private float edgeX = 40f;
    [SerializeField, Range(5, 19)]
    private float edgeY = 19f;

    public override Vector3 GetDesiredVelocity()
    {
        var maxSpeed = movable.VelocityLimit;
        var body = GetComponent<Rigidbody2D>();
        bool safeToWander = GetComponent<Animal>().safeToWander;
        bool isPredator = GetComponent<Animal>().runningFromPredator;
        int signX;
        int signY;
        if ((int)transform.position.x % 2 != 0) signX = 1;
        else signX = -1;
        if ((int)transform.position.y % 2 != 0) signY = 1;
        else signY = -1;
        float rnd = Random.Range(maxSpeed/2, maxSpeed);
        if (transform.position.x >= edgeX)
        {
            if(safeToWander || !isPredator) {
                if(transform.position.y <= -16) return new Vector3(-maxSpeed, rnd, 0) * maxSpeed;  
                else if(transform.position.y >= 16)return new Vector3(-maxSpeed, -rnd, 0) * maxSpeed;
            } 
            // //Debug.Log("RUN: " + new Vector3(-maxSpeed, 0, 0));
            //body.velocity = new Vector2(0, body.velocity.y);
            return new Vector3(-maxSpeed, rnd*signX, 0).normalized * maxSpeed;
        }
        if (transform.position.x <= -edgeX)
        {
            if(safeToWander || !isPredator) {
                if(transform.position.y <= -16) {
                    //Debug.Log($"T.p.x: {transform.position.x} T.p.y: {transform.position.y}");
                    //Debug.Log($"Vector: {new Vector3(maxSpeed, rnd, 0)}");
                    return new Vector3(maxSpeed, rnd, 0) * maxSpeed;
                }
                else if(transform.position.y >= 16) {
                    //Debug.Log($"T.p.x: {transform.position.x} T.p.y: {transform.position.y}");
                    //Debug.Log($"Vector: {new Vector3(maxSpeed, -rnd, 0)}");
                    return new Vector3(maxSpeed, -rnd, 0) * maxSpeed;
                }
            }
            ////Debug.Log("RUN");
            //body.velocity = new Vector2(0, body.velocity.y);
            return new Vector3(maxSpeed, rnd*signX, 0).normalized * maxSpeed*3;
        }
        if (transform.position.y >= edgeY)
        {
            if(safeToWander || !isPredator) {
                if(transform.position.x <= -35) {
                    //Debug.Log($"T.p.x: {transform.position.x} T.p.y: {transform.position.y}");
                    //Debug.Log($"Vector: {new Vector3(rnd, -maxSpeed, 0)}");
                    return new Vector3(rnd, -maxSpeed, 0) * maxSpeed;
                }
                else if(transform.position.x >= 35) {
                    //Debug.Log($"T.p.x: {transform.position.x} T.p.y: {transform.position.y}");
                    //Debug.Log($"Vector: {new Vector3(-rnd, -maxSpeed, 0)}");
                    return new Vector3(-rnd, -maxSpeed, 0) * maxSpeed;
                } 
            }
            //body.velocity = new Vector2(body.velocity.x, 0);
            return new Vector3(rnd*signY, -maxSpeed, 0).normalized * maxSpeed*3;
        }
        if (transform.position.y <= -edgeY)
        {
            if(safeToWander || !isPredator) {
                if(transform.position.x <= -35) {
                    // //Debug.Log($"T.p.x: {transform.position.x} T.p.y: {transform.position.y}");
                    // //Debug.Log($"Vector: {new Vector3(-rnd, maxSpeed, 0)}");
                    return new Vector3(rnd, maxSpeed, 0) * maxSpeed;
                }
                else if(transform.position.x >= 35) {
                    //Debug.Log($"T.p.x: {transform.position.x} T.p.y: {transform.position.y}");
                    //Debug.Log($"Vector: {new Vector3(-rnd, maxSpeed, 0)}");
                    return new Vector3(-rnd, maxSpeed, 0) * maxSpeed;
                }
            }
            //body.velocity = new Vector2(body.velocity.x, 0);
            return new Vector3(rnd*signY, maxSpeed, 0).normalized * maxSpeed*3;
        }

        return Vector3.zero;
    }

      public override void PrintLine(Vector3 desiredVelocity)
      {
            // //Debug.Log(GetType() + " V: " + desiredVelocity + " has DVM " + desiredVelocity.magnitude);
            Debug.DrawLine(transform.position, transform.position + desiredVelocity, Color.black);
      }
}