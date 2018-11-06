using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    AsyncOperation asyncLoadLevel;

    public void LoadLevel(string LevelName)
    {
        StartCoroutine(LoadLevelAsync(LevelName));
    }

    IEnumerator LoadLevelAsync(string LevelName)
    {
        asyncLoadLevel = SceneManager.LoadSceneAsync(LevelName, LoadSceneMode.Single);
        while (!asyncLoadLevel.isDone)
        {
            print("Loading the Scene");
            yield return null;
        }
    }
}
