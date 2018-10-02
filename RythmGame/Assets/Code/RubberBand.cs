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
                rolband1.transform.position = new Vector3(rolband1.transform.position.x - (11.0494f * 2), -1.52f, 0);
                rolband1Teleport = false;
                return;
            }
            else
            {
                rolband2.transform.position = new Vector3(rolband2.transform.position.x - (11.0494f * 2), -1.52f, 0);
                rolband1Teleport = true;
                return;
            }
        }

        rolband1.transform.position += new Vector3(Time.deltaTime * reader.mapSpeed, 0, 0);
        rolband2.transform.position += new Vector3(Time.deltaTime * reader.mapSpeed, 0, 0);
    }
}
