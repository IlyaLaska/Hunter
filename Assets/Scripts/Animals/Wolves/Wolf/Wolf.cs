﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Animal
{
    //private int lastAte = System.DateTime.Now.Second;
    private IEnumerator die;
    private void Start()
    {
        die = DieFromHunger(40);
        StartCoroutine(die);
    }
    private IEnumerator DieFromHunger(int dieInSecs)
    {
        yield return new WaitForSeconds(dieInSecs);
        this.gameObject.SetActive(false);
    }
    //public Wolf(int id) : base(id) { }
    private void OnTriggerEnter2D(Collider2D collision)//wolf knows of 2: GetComponent(Wolf) and another one you get from GetComponentsInChildren
    {
        if (!GetComponent<Collider2D>().IsTouching(collision)) return;
        string me = gameObject.name;
        string him = collision.name;
        if ((him == "Hunter" || him == "Doe" || him == "Hare") && GetComponent<CircleCollider2D>().name == "Wolf")
        {
            Debug.Log(me + " has eaten " + him);
            //lastAte = System.DateTime.Now.Second;
            StopCoroutine(die);
            die = DieFromHunger(40);
            StartCoroutine(die);
            collision.gameObject.SetActive(false);
        }
    }
}
