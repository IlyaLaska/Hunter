using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerBody;
    public GameObject player;
    public GameObject aim;
    public GameObject gun;
    public GameObject muzzle;

    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;
    public float bulletSpeedMultiplier = 1;
    public const int multiplierDuration = 30000;

    void Awake()
    {
        playerBody = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        handleShooting();
    }
    private void FixedUpdate()
    {
        handleMovement();
    }
    private void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Space.ToString())))//pressed Space
        {

        }
    }
    private void handleShooting()
    {
        if (Input.GetMouseButtonDown(0))//shooting
        {
            GameObject bullet = GM.bulletPoolInstance.GetObject();
            Vector3 shotPos = (muzzle.transform.position - player.transform.position).normalized;
            bullet.transform.position = muzzle.transform.position;
            bullet.SetActive(true);
            Vector2 velocity = new Vector2(shotPos.x * 20, shotPos.y * 20) * bulletSpeedMultiplier;
            bullet.GetComponent<Rigidbody2D>().velocity = velocity;
            bullet.GetComponent<Bullet>().Deactivate(10);//TODO IMPROVE
        }
    }

    private void handleMovement()
    {
        Vector2 input = Vector2.zero;
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input = input.normalized;
        playerBody.velocity = new Vector2(input.x * runSpeed, input.y * runSpeed);

        handleAiming();
        //(bool, float) aim = getAim();
    }

    private (bool, float) getAim()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDir = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        bool invert;
        if (angle > 90 || angle < -90)
        {
            invert = true;
        }
        else
        {
            invert = false;
        }
        return (invert, angle);
    }

    private void handleAiming()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDir = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        Vector3 localScale = Vector3.one * 2;
        if (angle > 90 || angle < -90)
        {
            localScale.y = -2f;
        }
        else
        {
            localScale.y = +2f;
        }
        aim.transform.localScale = localScale;
        aim.transform.eulerAngles = new Vector3(0, 0, angle);

    }

}
