using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doe : Animal
{
    public int groupId;
    //public Doe(int id, int groupId) : base(id)
    //{
    //    this.groupId = groupId;
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string me = gameObject.name;
        string him = collision.name;
    }
}
