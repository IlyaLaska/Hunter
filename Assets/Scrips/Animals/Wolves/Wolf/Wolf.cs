using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Animal
{
    public Wolf(int id) : base(id) { }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string me = gameObject.name;
        string him = collision.name;
        if(him == "Hunter" || him == "Doe(Clone)" || him == "Hare(Clone)")
        {
            Debug.Log(me + "has eaten " + him);
            collision.gameObject.SetActive(false);
        }
    }
}
