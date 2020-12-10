using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    private float xSize = 40f;
    private float ySize = 20f;
    bool escPressed = false;

    public static GM instance;
    public TMPro.TextMeshProUGUI magIndicator;

    public GameObject myPlayerPrefab;
    //public List<GameObject> players;

    //Bullet pool
    public ObjectPool bulletPool;
    public static ObjectPool bulletPoolInstance;

    public GameObject Hunter;
    //animals
    public GameObject hare;
    public GameObject wolf;
    public GameObject doe;

    [SerializeField]
    private int hareAmount;
    [SerializeField]
    private int wolfAmount;
    [SerializeField]
    private int doeGroupAmount;
    [SerializeField]
    private int doeInGroupMinAmount;
    [SerializeField]
    private int doeInGroupMaxAmount;

    //animal lists
    public List<GameObject> hareList;
    public List<GameObject> wolfList;
    public List<List<GameObject>> doeList;
    public HerdShepherd shepherd;

    void initAnimals()
    {
        hareList = new List<GameObject>();
        wolfList = new List<GameObject>();
        doeList = new List<List<GameObject>>();

        for (int i = 0; i < hareAmount; i++)
        {
            var xPos = UnityEngine.Random.Range(-xSize, xSize);
            var yPos = UnityEngine.Random.Range(-ySize, ySize);
            GameObject obj = Instantiate(hare, new Vector3(xPos, yPos, 0), new Quaternion());
            obj.name = "Hare";
            obj.GetComponent<Hare>().id = i;
            hareList.Add(obj);
        }
        for (int i = 0; i < wolfAmount; i++)
        {
            var xPos = UnityEngine.Random.Range(-xSize, xSize);
            var yPos = UnityEngine.Random.Range(-ySize, ySize);
            GameObject obj = Instantiate(wolf, new Vector3(xPos, yPos, 0), new Quaternion());
            obj.name = "Wolf";
            obj.GetComponent<Wolf>().id = i;
            wolfList.Add(obj);
        }
        for (int i = 0; i < doeGroupAmount; i++)
        {
            doeList.Add(new List<GameObject>());
            var doeAmunt = UnityEngine.Random.Range(doeInGroupMinAmount, doeInGroupMaxAmount);
            var xCentrePos = UnityEngine.Random.Range(-xSize, xSize);
            var yCentrePos = UnityEngine.Random.Range(-ySize, ySize);
            for (int j = 0; j < doeAmunt; j++)
            {
                var xPos = UnityEngine.Random.Range(-2, 2);
                var yPos = UnityEngine.Random.Range(-2, 2);
                GameObject obj = Instantiate(doe, new Vector3(xCentrePos+xPos, yCentrePos+yPos, 0), new Quaternion());
                obj.name = "Doe";
                obj.GetComponent<Doe>().id = j;
                obj.GetComponent<Doe>().groupId = i;
                doeList[i].Add(obj);
            }
        }
        Debug.Log("Setting doeList");
    }

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
        //shepherdList = new List<HerdShepherd>();
        initAnimals();
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
