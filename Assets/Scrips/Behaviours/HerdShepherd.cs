using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerdShepherd: AbstractBehaviour
{
    Doe doe;
    CircleCollider2D objectBody;
    List<GameObject> groupList;
    
    [SerializeField, Range(1,10)]
    private float separateWeight;
    [SerializeField, Range(1,10)]
    private float alignWeight;
    [SerializeField, Range(1,10)]
    private float cohesionWeight;
    private new void Start()
    {
        base.Start();
        doe = GetComponent<Doe>();
        objectBody = GetComponent<CircleCollider2D>();
        groupList = GM.instance.doeList[doe.groupId];
    }

    public override Vector3 GetDesiredVelocity()
    {
        int aliveInGroup = 0;
        foreach (var doe in groupList)
        {
            if (doe.activeInHierarchy) aliveInGroup++;
        }
        if (aliveInGroup <= 2) return Vector3.zero;
        Vector3 separate = Separate();
        Vector3 align = Align();
        Vector3 cohesion = Cohesion();
        return separate * separateWeight + align * alignWeight + cohesion * cohesionWeight;
    }

    private Vector3 Separate() 
    {
        float desiredseparation = objectBody.radius * 2;
        Vector3 sum = Vector3.zero;
        int count = 0;
        for (int i = 0; i < groupList.Count; i++)
        {
            if(i == doe.id) continue;
            float distance = Vector3.Distance(transform.position, groupList[i].transform.position);

            if (distance > 0 && distance < desiredseparation) 
            {
                Vector3 difference = (transform.position - groupList[i].transform.position).normalized;
                difference /= distance;
                sum += difference;
                count++;
            }
        }
        
        if(count > 0) {
            sum = (sum/count).normalized;
            sum *= movable.VelocityLimit;
        }
        return sum;
    }

    private Vector3 Align() 
    {
        Vector2 sum = Vector2.zero;

        for (int i = 0; i < groupList.Count; i++)
        {
            if(i == doe.id) continue;
            sum += groupList[i].GetComponent<Rigidbody2D>().velocity;
        }
        sum = (sum/groupList.Count).normalized;
        sum *= movable.VelocityLimit;
        
        Vector3 desired = new Vector3(sum.x, sum.y, 0);
        return desired;
    }

    private Vector3 Cohesion()
    {
        Vector3 groupCenter = Vector3.zero;

        for (int i = 0; i < groupList.Count; i++)
        {
            if(i == doe.id) continue;
            groupCenter += groupList[i].transform.position;
        }
        groupCenter = (groupCenter/groupList.Count).normalized;
        groupCenter *= movable.VelocityLimit;
        
        var desired = groupCenter - transform.position;
        desired = desired.normalized * movable.VelocityLimit;
        return desired;
    }
    
    public override void PrintLine(Vector3 desiredVelocity)
    {
        //Debug.Log(behaviour.GetType() + " V: " + desiredVelocity + " has DVM " + desiredVelocity.magnitude);
        Debug.DrawLine(transform.position, transform.position + desiredVelocity, Color.yellow);
    }
    
}


