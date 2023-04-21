using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EquationGenerator))]
public class EquationScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EquationGenerator equationGenerator = (EquationGenerator)target;

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("SquarePrefab");
        equationGenerator.SquarePrefab = (GameObject)EditorGUILayout.
            ObjectField(equationGenerator.SquarePrefab, typeof(GameObject), true);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        equationGenerator.xIntervalBetweenBlocks =
            EditorGUILayout.Slider("XInterval", equationGenerator.xIntervalBetweenBlocks, 0, 2);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        equationGenerator.yIntervalBetweenBlocks =
            EditorGUILayout.Slider("YInterval", equationGenerator.yIntervalBetweenBlocks, 0, 2);
        EditorGUILayout.EndHorizontal();

        if(GUILayout.Button("Generate Equation"))
        {
            equationGenerator.MakeEquation();
        }


    }
}
