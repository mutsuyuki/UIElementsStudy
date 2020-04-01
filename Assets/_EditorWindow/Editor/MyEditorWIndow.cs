using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;


public class MyEditorWIndow : EditorWindow {
    
    //[MenuItem("Window/MyEditorWindow")] ←実践ではこのように書く
    [MenuItem("MyEditorWindowMenu/Open")]
    static void Open() {
        // 単数Window作成のみ許可する場合
        GetWindow<MyEditorWIndow>();
        
        // 複数Window作成を許可する場合
        // var exampleWindow = CreateInstance<MyEditorWIndow> ();
        // exampleWindow.Show ();
    }

    private bool on;
    private bool selected;
    private ExamplePupupContent popupContent = new ExamplePupupContent ();

    void OnGUI() {
        EditorGUILayout.LabelField("------トグル-------------------------------");
        EditorGUILayout.ToggleLeft("Toggle", false);
        EditorGUILayout.Space(16);

        EditorGUILayout.LabelField("------オブジェクト-------------------------------");
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.ObjectField(null, typeof(Object), false);
        EditorGUILayout.ObjectField(null, typeof(Material), false);
        EditorGUILayout.ObjectField(null, typeof(AudioClip), false);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space(16);

        EditorGUILayout.LabelField("------テクスチャ-------------------------------");
        EditorGUILayout.BeginHorizontal();
        var options = new[] {GUILayout.Width(64), GUILayout.Height(64)};
        EditorGUILayout.ObjectField(null, typeof(Texture), false, options);
        EditorGUILayout.ObjectField(null, typeof(Sprite), false, options);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space(16);

        EditorGUILayout.LabelField("------インデント-------------------------------");
        EditorGUILayout.LabelField("Parent");
        EditorGUI.indentLevel++;
        EditorGUILayout.LabelField("Child");
        EditorGUILayout.LabelField("Child");
        EditorGUI.indentLevel--;
        EditorGUILayout.LabelField("Parent");
        EditorGUI.indentLevel++;
        EditorGUILayout.LabelField("Child");
        EditorGUI.indentLevel--;
        EditorGUILayout.Space(16);

        EditorGUILayout.LabelField("------色指定-------------------------------");
        GUI.backgroundColor = Color.red;
        GUILayout.Button("color button");
        GUI.backgroundColor = Color.yellow;
        GUILayout.Button("color button");
        GUI.backgroundColor = Color.white;
        EditorGUILayout.Space(16);


        EditorGUILayout.LabelField("------トグルボタン-------------------------------");
        on = GUILayout.Toggle(on, on ? "on" : "off", "button");
        EditorGUILayout.Space(16);
        
        
        EditorGUILayout.LabelField("------ポップアップ-------------------------------");
        if (GUILayout.Button ("PopupContent",GUILayout.Width(128))) {
            var activatorRect = GUILayoutUtility.GetLastRect ();
            PopupWindow.Show (activatorRect, popupContent);
        }
    }
}




public class ExamplePupupContent : PopupWindowContent
{
    public override void OnGUI (Rect rect)
    {
        EditorGUILayout.LabelField ("Lebel");
    }

    public override void OnOpen ()
    {
        Debug.Log ("表示するときに呼び出される");
    }

    public override void OnClose ()
    {
        Debug.Log ("閉じるときに呼び出される");
    }

    public override Vector2 GetWindowSize ()
    {
        //Popup のサイズ
        return new Vector2 (300, 100);
    }
}