using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(UIElementCustomEditorTestObject))]
public class UIElementCustomEditor : Editor {


    // エディタ拡張の場合、OnInspectorGUIではなくCreateInspectorGUIを使う
    public override VisualElement CreateInspectorGUI() {
        var root = new VisualElement();

        // デフォルトのInspector表示を追加
        IMGUIContainer defaultInspector = new IMGUIContainer(() => DrawDefaultInspector());
        root.Add(defaultInspector);

        // IMGUIContainerを使ってIMGUIでUIを描画
        root.Add(new IMGUIContainer(() => {
            GUILayout.Space(16);
            GUILayout.BeginVertical("Box");
            GUILayout.Label("ここはIMGUIの拡張です");
            if (GUILayout.Button("Buttom From IMGUI")) {
                Debug.Log("Click IMGUI Button.");
            }

            GUILayout.EndVertical();
        }));

        // カスタム用のVisualElementを追加
        
        var uxmlPath = "Assets/_UIElementsCustomEditor/Editor/" + typeof(UIElementCustomEditor).Name + ".uxml";
        var uxml = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(uxmlPath);
        root.Add(uxml.CloneTree());

        // VisualElementのボタンイベントを追加
        var button1 = root.Q<Button>("button1");
        var target1 = serializedObject.targetObject as UIElementCustomEditorTestObject;
        if (button1 != null && target1 != null) {
            button1.clickable.clicked += target1.Connect1;
        }

        var button２ = root.Q<Button>("button2");
        var target２ = serializedObject.targetObject as UIElementCustomEditorTestObject;
        if (button２ != null && target２ != null) {
            button２.clickable.clicked += target２.Connect2;
        }

        return root;
    }
}