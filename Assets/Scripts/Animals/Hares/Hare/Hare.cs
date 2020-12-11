using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hare : Animal
{
    //public Hare(int id) : base(id) { }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string me = gameObject.name;
        string him = collision.name;
    }
}
