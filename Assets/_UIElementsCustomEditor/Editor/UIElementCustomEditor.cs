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
        var target = serializedObject.targetObject as UIElementCustomEditorTestObject;
        if (target == null)
            return root;

        var childButton1 = root.Q<Button>("ChildButton1");
        if (childButton1 != null) {
            childButton1.clickable.clicked += target.Connect1;
        }

        var childButton2 = root.Q<Button>("ChildButton2");
        if (childButton2 != null) {
            childButton2.clickable.clicked += target.Connect2;
        }
        
        var parentButton = root.Q<Button>("ParentButton");
        if (parentButton != null) {
            parentButton.clickable.clicked += target.Connect3;
        }

        return root;
    }
}