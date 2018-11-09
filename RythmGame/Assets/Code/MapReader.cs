using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapReader : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource debugMusic;
    [SerializeField] private bool debug;
    [SerializeField] private PlayerInput input;

    [SerializeField] private GameObject sliceObj;

    [SerializeField] private GameObject fish;
    [SerializeField] private GameObject deeg;
    [SerializeField] private GameObject komkomer;
    [SerializeField] private GameObject prij;
    [SerializeField] private GameObject longkomer;

    Dictionary<string, GameObject> objects = new Dictionary<string, GameObject>();

    [SerializeField] private LevelData mapdata;
    public float mapSpeed;
    public float spawnDelayMultiplier;

    public Text text;
    public Text scoreText;
    public float timeOffset;

    int objSpawnCount;
    public List<GameObject> sliceObjs = new List<GameObject>();
    public List<Vector3> positions = new List<Vector3>();
    public RubberBand band;
    public PlayerInput player;
    int counter;

    Vector3 startPos;
    float difference;
    bool started;

    private void Awake()
    {
        objects.Add("Fish", fish);
        objects.Add("Deeg", deeg);
        objects.Add("Komkomer", komkomer);
        objects.Add("Prij", prij);
        objects.Add("Longkomer", longkomer);
    }

    private void Start()
    {
        startPos = transform.position;

        for (int i = 0; i < 20; i++)
        {
            PositionNext();
        }

        for (int i = 0; i < mapdata.LevelItems.Count; i++)
        {
            startPos = transform.position;

            GameObject g = Instantiate(objects[mapdata.LevelItems[i].ItemID], Spawn(mapdata.LevelItems[i].SpawnSecondinGame, 3f), Quaternion.identity);
            g.transform.SetParent(this.transform);

        }

    }

    public void GameStart()
    {
        if (!debug)
            music.Play();
        else
            debugMusic.Play();

        started = true;
        band.started = true;
        player.started = true;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !started)
            GameStart();

        difference = startPos.x - transform.position.x;

        if (started == false)   
            return;

        float x = transform.position.x;
        x += Time.deltaTime * spawnDelayMultiplier;
        transform.position = new Vector3(x, 0, 0);
        text.text = Time.timeSinceLevelLoad.ToString();
    }

    public Vector3 Spawn(double spawnTime, float yOffset)
    {
        Vector3 returnVec = Vector3.zero;
        returnVec.x = -(float)(spawnTime);
        returnVec.x *= spawnDelayMultiplier;
        returnVec.y -= yOffset;
        return returnVec;
    }

    public void PositionNext()
    {
        if (counter >= input.clickTimes.Count)
            return;
        Vector3 pos = positions[counter];
        pos.x -= difference;
        sliceObjs[objSpawnCount].transform.position = pos;
        if(counter < input.clickTimes.Count)
            counter++;
        objSpawnCount++;
        if (objSpawnCount >= 20)
            objSpawnCount = 0;
    }
}

public struct MapData
{
    
}

