using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustDestroyOnEnter : MonoBehaviour {

    public MapReader reader;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slice"))
        {
            reader.PositionNext();
        }
    }
}
