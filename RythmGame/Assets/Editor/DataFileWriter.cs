using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DataFileWriter {

    public DataFileWriter()
    {

    }

    public void WriteToFile(string Filename, string ItemID, double SpawnSecond, List<double> SliceSeconds)
    {
        if (AssetDatabase.FindAssets(Filename).Length == 0)
        {
            //Create a new scriptable object and fill it
            LevelData data = ScriptableObject.CreateInstance<LevelData>();
            data.LevelItems.Add(new LevelData.ItemValues(ItemID, SpawnSecond, SliceSeconds));

            AssetDatabase.CreateAsset(data, "Assets/resources/LevelData/" + Filename + ".asset");
        }

        else
        {
            //Load data en add new data to it
            LevelData data = (LevelData)AssetDatabase.LoadAssetAtPath("Assets/resources/LevelData/" + Filename + ".asset", typeof(LevelData));
            data.LevelItems.Add(new LevelData.ItemValues(ItemID, SpawnSecond, SliceSeconds));
        }

        //Save Data
        AssetDatabase.SaveAssets();
    }
}
