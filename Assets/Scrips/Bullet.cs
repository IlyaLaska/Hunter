using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // public delegate void GameOver();
    // public static event GameOver gameOverEvent;
    public IEnumerator deactivate;
    void Start()
    {
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;
        if (tag == "CanFallOffCliff")
        {
            collision.gameObject.SetActive(false);
            Debug.Log(collision.name + " has been shot");
        }
        Debug.Log($"Bullet hit");
        StopCoroutine(deactivate);
        gameObject.SetActive(false);
    }
    public void Deactivate(int deactivateIn)
    {
        deactivate = DeactivateRoutine(deactivateIn);
        StartCoroutine(deactivate);
    }
    private IEnumerator DeactivateRoutine(int deactivateIn)
    {
        yield return new WaitForSeconds(deactivateIn);
        this.gameObject.SetActive(false);
    }
}
