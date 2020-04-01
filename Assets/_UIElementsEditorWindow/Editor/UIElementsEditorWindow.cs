using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class UIElementsEditorWindow : EditorWindow {
    public string _position;

    [MenuItem("MyUIElementsEditorWindow/Open")]
    public static void ShowExample() {
        UIElementsEditorWindow window = GetWindow<UIElementsEditorWindow>();
        window.titleContent = new GUIContent("UIElementsEditorWindow");
    }

    public void OnEnable() {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Import UXML
        var uxmlPath = "Assets/_UIElementsEditorWindow/Editor/UIElementsEditorWindow.uxml";
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(uxmlPath);
        root.Add(visualTree.CloneTree());

        var editorWindowDataPath = "Assets/_UIElementsEditorWindow/Editor/UIElementsEditorWindowData.asset";
        var editorWindowData = AssetDatabase.LoadAssetAtPath<UIElementsEditorWindowData>(editorWindowDataPath);
        var serializedObject = new SerializedObject(editorWindowData);
        root.Bind(serializedObject);
    }
}