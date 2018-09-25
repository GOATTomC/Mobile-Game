using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapReader : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    [SerializeField] private GameObject sliceObj;

    [SerializeField] private GameObject fish;
    [SerializeField] private GameObject deeg;
    [SerializeField] private GameObject komkomer;

    Dictionary<string, GameObject> objects = new Dictionary<string, GameObject>();

    [SerializeField] private LevelData mapdata;
    public float mapSpeed;

    public Text text;
    public Text scoreText;

    private void Awake()
    {
        objects.Add("Fish", fish);
        objects.Add("Deeg", deeg);
        objects.Add("Komkomer", komkomer);
    }

    private void Start()
    {
        for (int i = 0; i < mapdata.LevelItems.Count; i++)
        {

            GameObject g = Instantiate(objects[mapdata.LevelItems[i].ItemID], Spawn(mapdata.LevelItems[i].SpawnSecondinGame), Quaternion.identity);
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
        x += Time.deltaTime * mapSpeed;
        transform.position = new Vector3(x, 0, 0);
        text.text = Time.timeSinceLevelLoad.ToString();
    }

    public Vector3 Spawn(double spawnTime)
    {
        Vector3 returnVec = Vector3.zero;
        returnVec.x = -(float)(spawnTime);
        return returnVec;
    }

    public Vector3 Spawn(double spawnTime, float multiplier)
    {
        Vector3 returnVec = Vector3.zero;
        returnVec.x = -(float)(spawnTime / multiplier);
        return returnVec;
    }
}

public struct MapData
{
    
}

