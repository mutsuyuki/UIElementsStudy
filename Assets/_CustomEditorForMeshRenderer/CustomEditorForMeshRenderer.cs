using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshRenderer))]
public class CustomEditorForMeshRenderer : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        // メッシュの色を変える
        GUILayout.BeginVertical("Box");
        GUILayout.Label("Color");
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Random")) {
            ((MeshRenderer) target).sharedMaterial.SetColor("_BaseColor", Random.ColorHSV());
        }

        if (GUILayout.Button("Clear")) {
            ((MeshRenderer) target).sharedMaterial.SetColor("_BaseColor", Color.white);
        }

        GUILayout.EndHorizontal();
        GUILayout.EndVertical();

        // メッシュの大きさを変える
        GUILayout.BeginVertical("Box");
        GUILayout.Label("Scale");
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Random")) {
            ((MeshRenderer) target).transform.localScale = Vector3.one * Random.Range(0.5f, 4f);
        }

        if (GUILayout.Button("Reset")) {
            ((MeshRenderer) target).transform.localScale = Vector3.one;
        }

        GUILayout.EndHorizontal();
        GUILayout.EndVertical();

        // 位置を変える
        GUILayout.BeginVertical("Box");
        GUILayout.Label("Position");
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Random")) {
            ((MeshRenderer) target).transform.localPosition = new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f)
            );
        }

        if (GUILayout.Button("Reset")) {
            ((MeshRenderer) target).transform.localPosition = Vector3.zero;
        }

        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
    }
}