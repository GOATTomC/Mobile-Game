using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Level data", order = 1)]
public class LevelData : ScriptableObject {

    [System.Serializable]
    public struct ItemValues
    {
        public ItemValues(string Item, double SpawnSecond, List<double> SliceSeconds)
        {
            ItemID = Item;
            SpawnSecondinGame = SpawnSecond;
            SliceSecondsInGame = SliceSeconds;
        }

        public string ItemID;
        public double SpawnSecondinGame;
        public List<double> SliceSecondsInGame;
    }

    [SerializeField]
    public List<ItemValues> LevelItems = new List<ItemValues>();
}
