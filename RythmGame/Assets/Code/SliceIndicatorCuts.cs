using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceIndicatorCuts : MonoBehaviour
{
    [SerializeField] private Transform systemParent;
    [SerializeField] private GameObject fishCut;
    [SerializeField] private GameObject deegCut;
    [SerializeField] private GameObject komkomerCut;

    private GameObject currentObj;

    public static SliceIndicatorCuts Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Fish"))
            currentObj = fishCut;
        else if (other.gameObject.name.Contains("Deeg"))
            currentObj = deegCut;
        else if (other.gameObject.name.Contains("Komkomer"))
            currentObj = komkomerCut;
    }

    public void Cut()
    {
        GameObject g = Instantiate(currentObj, Vector3.zero, Quaternion.identity);
        g.transform.SetParent(systemParent);
    }
}
