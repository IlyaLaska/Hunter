using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Align : AbstractBehaviour
{

    public override Vector3 GetDesiredVelocity()
    {
        return new Vector3(0, 0, 0);
        Vector3 sum = new Vector3(0, 0, 0);
    }
}
