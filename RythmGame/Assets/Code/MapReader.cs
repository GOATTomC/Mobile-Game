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
        for (int i = 0; i < mapdata.LevelItems.Count; i++)
        {

            GameObject g = Instantiate(objects[mapdata.LevelItems[i].ItemID], Spawn(mapdata.LevelItems[i].SpawnSecondinGame - timeOffset, 3f), Quaternion.identity);
            g.transform.SetParent(this.transform);

            for (int j = 0; j < mapdata.LevelItems[i].SliceSecondsInGame.Count; j++)
            {
                GameObject SliceObj = Instantiate(sliceObj, Spawn(mapdata.LevelItems[i].SliceSecondsInGame[j] - timeOffset, 1.5f), transform.rotation);
                input.clickTimes.Add(mapdata.LevelItems[i].SliceSecondsInGame[j] * Time.timeScale);
                SliceObj.transform.SetParent(this.transform);
            }
        }

        if (!debug)
            music.Play();
        else
            debugMusic.Play();
    }

    private void Update()
    {
        if (!music.isPlaying)
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
}

public struct MapData
{
    
}

