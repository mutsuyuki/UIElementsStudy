using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "MyScriptableObject/Create MyScriptableObject Instance")]
public class MyScriptableObject : ScriptableObject {
    [SerializeField]
    private MyChildScriptableObject child;

    [SerializeField]
    string str;

    [SerializeField, Range(0, 10)]
    int number;

    [MenuItem("MyScriptableObjectMenu/Create MyScriptableObject Instance")]
    static void CreateMyScriptableObjectInstance() {
        var savePath = "Assets/_ScriptableObject/Editor/MyScriptableObject.asset";

        //親をインスタンス化
        var parent = ScriptableObject.CreateInstance<MyScriptableObject>();

        //子をインスタンス化
        parent.child = ScriptableObject.CreateInstance<MyChildScriptableObject>();
        parent.child.hideFlags = HideFlags.HideInHierarchy;

        //親に child オブジェクトを追加
        AssetDatabase.AddObjectToAsset(parent.child, savePath);

        //親をアセットとして保存
        AssetDatabase.CreateAsset(parent, savePath);

        //インポート処理を走らせて最新の状態にする
        AssetDatabase.ImportAsset(savePath);
    }

    [MenuItem("MyScriptableObjectMenu/Load MyScriptableObject")]
    static void LoadMyScriptableObject() {
        var path = "Assets/_ScriptableObject/Editor/MyScriptableObject.asset";
        var myScriptableObject = AssetDatabase.LoadAssetAtPath<MyScriptableObject>(path);
        Debug.Log(myScriptableObject);
    }
}