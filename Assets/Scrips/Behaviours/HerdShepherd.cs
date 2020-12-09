using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerdShepherd: AbstractBehaviour
{
    Doe doe;
    CircleCollider2D objectBody;
    List<GameObject> groupList;
    private void Start()
    {
        base.Start();
        doe = GetComponent<Doe>();
        objectBody = GetComponent<CircleCollider2D>();
        groupList = GM.instance.doeList[doe.groupId];

    }

    public override Vector3 GetDesiredVelocity()
    {
        
        return new Vector3(0, 0, 0);
    }

    private Vector3 Separate() 
    {
        float desiredseparation = objectBody.radius*2

    }
}


