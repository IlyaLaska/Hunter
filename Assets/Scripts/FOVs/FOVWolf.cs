using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVWolf : MonoBehaviour
{
    ChaseSmartWolf chase;
    Animal animal;
    // Start is called before the first frame update
    void Start()
    {
        chase = GetComponentInParent<ChaseSmartWolf>();
        animal = GetComponentInParent<Animal>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string hisName = collision.name;
        if (hisName == "Hunter" || hisName == "Hare" || hisName == "Doe")
        {
            animal.safeToWander = false;
            chase.chaseList.Add((collision.gameObject, collision.gameObject.GetComponent<Rigidbody2D>()));
            //Debug.Log(chase.name + " now chasing " + hisName);
        }
    }
}
