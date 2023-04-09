/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

#if UNITY_EDITOR
public class Aboba : EditorWindow
{
    [MenuItem("VinTools/Editor Windows/Rule Tile Generator")]
    public static void ShowWindow()
    {
        GetWindow<Aboba>("Rule Tile Generator");
    }

    Vector2 scrollpos;
    private void OnGUI()
    {
        scrollpos = GUILayout.BeginScrollView(scrollpos);

        if (templ_neighbors.Count == 0)
        {
            EditorGUILayout.Space();
            GUILayout.Label("Template setup", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            ScriptableObject target = this;
            SerializedObject so = new SerializedObject(target);
            SerializedProperty prp = so.FindProperty("templateSprites");
            EditorGUILayout.PropertyField(prp, true); //true - показывать дочерние
            so.ApplyModifiedProperties();

            GUILayout.Box("Shift select all of the sprites and drag them here...           ",
            EditorStyles.helpBox);

            EditorGUILayout.Space();

            if (GUILayout.Button("Load Template"))
            {
                LoadTemplate();
            }
        }

        GUILayout.EndScrollView();
    }

    public List<Vector3Int> NeighborPositions = new List<Vector3Int>()
    {
        new Vector3Int(-1,1,0),
        new Vector3Int(0,1,0),
        new Vector3Int(1,1,0),
        new Vector3Int(-1,0,0),
        new Vector3Int(1,0,0),
        new Vector3Int(-1,1,0),
        new Vector3Int(0,-1,0),
        new Vector3Int(1,-1,0),
    };

    public Sprite[] templateSprites = new Sprite[0];
    public List<List<int>> templ_neighbors = new List<List<int>>();

    void LoadTemplate()
    {
        templ_neighbors = new List<List<int>>();

        int i = 0;
        foreach(var item in templateSprites)
        {
            List<int> neighborRules = new List<int>();

            Rect slice = item.rect;
            Color[] cols = item.texture.GetPixels((int)slice.x, (int)slice.y, (int)slice.width, (int)slice.height);

            Texture2D tex = new Texture2D((int)slice.width,(int)slice.height, TextureFormat.ARGB32, false);
            tex.SetPixels(0,0, (int)slice.width, (int)slice.height, cols);
            tex.filterMode = FilterMode.Point;
            tex.Apply(); 

            Vector2 size = new Vector2Int(tex.width, tex.height);

        }
    }
}

#endif */