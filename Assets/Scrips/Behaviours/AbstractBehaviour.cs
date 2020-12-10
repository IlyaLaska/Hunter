using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBehaviour : MonoBehaviour
{
    [SerializeField, Range(0, 10000)]
    private float weight = 1f;

    public float Weight => weight;

    protected Movable movable;
    // Start is called before the first frame update
    protected void Start()
    {
        movable = GetComponent<Movable>();
        //Debug.Log(gameObject.name + " has movable " + movable.gameObject.name);
    }
    public abstract Vector3 GetDesiredVelocity();
    public abstract void PrintLine(Vector3 desiredVelocity);

}
