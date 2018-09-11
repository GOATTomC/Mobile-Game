using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnEditor : EditorWindow {

    private bool m_Folded = false;
    private int m_SliceAmount = 0;
    private Vector2 m_ScrollPosition;
    private bool m_KeepChanges = false;

    private string m_ItemID = "";
    private string m_FileName = "";
    private double m_SpawnSecond = 0;

    private List<double> m_SliceTimes = new List<double>();


    //Open and Focus on the editor window
    [MenuItem("Window/Object Spawn Editor")]
    static void Init()
    {
        SpawnEditor editorWindow = (SpawnEditor)EditorWindow.GetWindow((typeof(SpawnEditor)));
        editorWindow.Show();
        editorWindow.Focus();
    }

    //Draws the window contents
    private void OnGUI()
    {
        m_Folded = EditorGUILayout.Foldout(m_Folded, "Item values");

        //Draw all the values that can be folded
        DrawFoldedValues();

        //File name to write to
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("File name: ");
        m_FileName = EditorGUILayout.TextField(m_FileName);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Keep values: ");
        m_KeepChanges = EditorGUILayout.Toggle(m_KeepChanges);
        EditorGUILayout.EndHorizontal();

        //Draw add button
        DrawAddButton();
    }

    private void DrawFoldedValues()
    {
        //Item values fold out
        if (m_Folded)
        {
            EditorGUILayout.BeginVertical();

            //Item ID
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Item ID: ");
            m_ItemID = EditorGUILayout.TextField(m_ItemID);
            EditorGUILayout.EndHorizontal();

            // item Spawn
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Second in game to spawn item");
            m_SpawnSecond = EditorGUILayout.DoubleField(m_SpawnSecond);
            EditorGUILayout.EndHorizontal();

            //Draw list for multiple values
            EditorGUILayout.LabelField("");
            DrawListSize();
            DrawList();

            EditorGUILayout.EndVertical();
        }
    }

    private void DrawListSize()
    {
        //How many slices so we can change the list
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Slice amount: ");
        m_SliceAmount = EditorGUILayout.IntField(m_SliceAmount);
        EditorGUILayout.EndHorizontal();

        //Limit the amount of slices (prevent mistakes)
        if (m_SliceAmount > 10)
            m_SliceAmount = 10;
        else if (m_SliceAmount < 0)
            m_SliceAmount = 0;

        //When changing list size keep the data
        if (m_SliceAmount != m_SliceTimes.Count)
        {
            double[] array = new double[m_SliceAmount];

            for (int i = 0; i < m_SliceTimes.Count && i < m_SliceAmount; ++i)
            {
                array[i] = m_SliceTimes[i];
            }

            m_SliceTimes = new List<double>(array);
        }
    }
    //Draw list of doubles
    private void DrawList()
    {
        m_ScrollPosition = EditorGUILayout.BeginScrollView(m_ScrollPosition);
        for (int i = 0; i < m_SliceTimes.Count; ++i)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Second in game for slice: ");
            m_SliceTimes[i] = EditorGUILayout.DoubleField(m_SliceTimes[i]);
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndScrollView();
    }

    private void DrawAddButton()
    {
        //Create a blank line
        EditorGUILayout.LabelField("");

        if (GUILayout.Button("Add"))
        {
            if (!m_KeepChanges)
            {
                //Reset the item values if the user does not want to keep them
                ResetValues();
            }
        }
    }

    //Resets all values
    private void ResetValues()
    {
        m_ItemID = "";
        m_SpawnSecond = 0;
        m_SliceAmount = 0;
        m_SliceTimes = new List<double>();
    }
}
