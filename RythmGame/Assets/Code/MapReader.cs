using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapReader : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    [SerializeField] private GameObject sliceObj;
    [SerializeField] private GameObject fish;

    Dictionary<string, GameObject> objects = new Dictionary<string, GameObject>();

    [SerializeField] private LevelData mapdata;
    [SerializeField] private float beatSpeed;
    public float BeatSpeed { get { return beatSpeed; } }

    public bool hard;
    public Text text;

    private void Awake()
    {
        objects.Add("Fish", fish);
        if(hard)
            Time.timeScale = 0.1f;
    }

    private void Start()
    {
        for (int i = 0; i < mapdata.LevelItems.Count; i++)
        {

            GameObject g = Instantiate(objects[mapdata.LevelItems[i].ItemID],
                                       Spawn(mapdata.LevelItems[i].SpawnSecondinGame),
                                       transform.rotation);
            g.transform.SetParent(this.transform);

            for (int j = 0; j < mapdata.LevelItems[i].SliceSecondsInGame.Count; j++)
            {
                GameObject SliceObj = Instantiate(sliceObj, Spawn(mapdata.LevelItems[i].SliceSecondsInGame[j]), transform.rotation);
                input.clickTimes.Add(mapdata.LevelItems[i].SliceSecondsInGame[j] * Time.timeScale);
                SliceObj.transform.SetParent(this.transform);
            }
        }
    }

    private void Update()
    {
        float x = transform.position.x;
        x += Time.deltaTime * beatSpeed;
        transform.position = new Vector3(x, 0, 0);
        text.text = (Time.timeSinceLevelLoad / Time.timeScale).ToString();
    }

    public Vector3 Spawn(double spawnTime)
    {
        Vector3 returnVec = Vector3.zero;
        returnVec.x = (float)spawnTime * -beatSpeed;
        return returnVec;
    }
}

public struct MapData
{
    
}

