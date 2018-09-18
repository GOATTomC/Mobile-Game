using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapReader : MonoBehaviour
{
    private void Awake()
    {
        //get map data
    }
}

public struct MapData
{
    
}

public struct SliceItem
{
    public AnimalTypes animalType;
}

public enum AnimalTypes
{
    fish,
    weed,
    rice
};
