using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberBand : MonoBehaviour
{
    [SerializeField] private MapReader reader;

    [SerializeField] private GameObject rolband1;
    [SerializeField] private GameObject rolband2;
    [SerializeField] private float mapLimit;

    bool rolband1Teleport = true;


    private void Update()
    {
        if(rolband1.transform.position.x > mapLimit || rolband2.transform.position.x > mapLimit)
        {
            print("limit");
            if (rolband1Teleport == true)
            {
                rolband1.transform.position = new Vector3(rolband1.transform.position.x - (26.06f * 2), 0.4637145f, 0.00878546f);
                rolband1Teleport = false;
                print("band1");
            }
            else
            {
                rolband2.transform.position = new Vector3(rolband2.transform.position.x - (26.06f * 2), 0.4637145f, 0.00878546f);
                rolband1Teleport = true;
                print("band2");
            }
        }

        rolband1.transform.position += new Vector3(reader.BeatSpeed * Time.deltaTime, 0, 0);
        rolband2.transform.position += new Vector3(reader.BeatSpeed * Time.deltaTime, 0, 0);
    }
}
