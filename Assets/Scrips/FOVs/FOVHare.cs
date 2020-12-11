using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVHare : MonoBehaviour
{
    FleeSmartHare flee;
    Animal animal;
    // Start is called before the first frame update
    void Start()
    {
        flee = GetComponentInParent<FleeSmartHare>();
        animal = GetComponentInParent<Animal>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string hisName = collision.name;
        if(hisName == "Hare" || hisName == "Doe") animal.runningFromPredator = false;
        if(hisName == "Hunter" || hisName == "Hare" || hisName == "Wolf" || hisName == "Doe")
        {
            animal.safeToWander = false;
            animal.runningFromPredator = true;
            flee.fleeFrom.Add((collision.gameObject, collision.gameObject.GetComponent<Rigidbody2D>()));
            Debug.Log(flee.name + " now fleeing from " + hisName);
        }
    }
}
