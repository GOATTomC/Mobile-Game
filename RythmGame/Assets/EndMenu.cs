using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndMenu : MonoBehaviour
{
    int nummer;
    public int levelIndex;
    public List<TMP_InputField> obj = new List<TMP_InputField>();
    public ServerControl server;

    public void AddLetter(string letter)
    {
        if (nummer >= 3)
            return;

        obj[nummer].text = letter;
        nummer++;
    }

    public void RemoveLetter()
    {
        if (nummer <= 0)
            return;

        obj[nummer - 1].text = "";
        nummer--;
    }

    public void Send()
    {
        string name = "";
        for (int i = 0; i < obj.Count; i++)
        {
            name += obj[i].text;
        }

        float score = ScoreManager.instance.totalScore;
        server.UploadScore(name, (int)score, levelIndex);
        Cancel();
    }

    public void Cancel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        gameObject.SetActive(false);
    }
}
