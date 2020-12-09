using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    bool escPressed = false;

    public static GM instance;
    public TMPro.TextMeshProUGUI magIndicator;

    public GameObject myPlayerPrefab;
    //public List<GameObject> players;

    //Bullet pool
    public ObjectPool bulletPool;
    public static ObjectPool bulletPoolInstance;

    void Awake()
    {
        bulletPoolInstance = bulletPool;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying GM object!");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    internal void EndGame(string winnerName)
    {
        GoToMainMenu();
    }
    internal void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void OnGUI()
    {
        handleExit();
    }

    private void handleExit()
    {
        if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Escape.ToString())))//pressed Escape
        {
            if (escPressed)
            {
                GoToMainMenu();
            }
            else
            {
                escPressed = true;
            }
        }
    }
}
