using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;
        if(tag == "CanFallOffCliff")
        {
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
            Debug.Log(collision.name + " has fallen off a cliff");
        }
        
    }
}
