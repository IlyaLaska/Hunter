using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separation : AbstractBehaviour
{
    // Start is called before the first frame update
    private HerdShepherd shepherd;
    CircleCollider2D objectCollider;
    List<GameObject> groupList;
    void Start()
    {

        
    }

    public override Vector3 GetDesiredVelocity()
    {
        float desiredseparation = objectCollider.radius * 2;
        Vector3 sum = new Vector3(0, 0, 0);
        int count = 0;
        for (int i = 0; i < groupList.Capacity; i++)
        {
            float distance = Vector3.Distance(transform.position, groupList[i].transform.position);
            if ((distance > 0) && (distance < desiredseparation)) 
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

}
