using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[CustomEditor(typeof(DefaultEditorExtendCheck))]
public class DefaultEditorExtendCheckEditorExtend : Editor {

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        GUILayout.BeginVertical("Box");
        GUILayout.Label("ここは別プログラムの拡張で実行しています");
        GUILayout.Label("Change Number 1");
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Num1 To 0")) {
            ((DefaultEditorExtendCheck) target).num1 = 0;
        }

        if (GUILayout.Button("Num1 To 10")) {
            ((DefaultEditorExtendCheck) target).num1 = 10;
        }

        if (GUILayout.Button("Num1 To Random")) {
            ((DefaultEditorExtendCheck) target).num1 = Random.Range(0, 10);
        }

        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
    }

    private void OnSceneGUI() {
        Debug.Log("Log From DefaultEditorExtendCheckEditorExtend's OnSceneGUI()");
    }
}