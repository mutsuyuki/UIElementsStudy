using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEditor;

[RequireComponent(typeof(Transform))] // 最低1つは指定されたコンポーネントがアタッチされてなければいけない
[DisallowMultipleComponent] // 1つのゲームオブジェクトに同じコンポーネントを複数アタッチすることを禁止
[AddComponentMenu("MyEditorExtends/DefaultEditorExtendCheck")] //Component メニューにメニュー項目を追加します。 
[ExecuteInEditMode] // ゲーム再生中でなくても MonoBehaviour の主要な関数が呼び出されるようになります。
[SelectionBase] // SelectionBase 属性の付いたゲームオブジェクトで最下層の子要素から順に選択できます。
public class DefaultEditorExtendCheck : MonoBehaviour {
    [Header("---- 数値セッティング --------------------------------------")]
    [Range(1, 10)]
    public int num1 = 5;

    [Range(1, 10)]
    public float num2 = 5;

    [Range(1, 10)]
    public long num3 = 5;

    [Range(1, 10)]
    public double num4 = 5;

    [Header("---- 文字列セッティング --------------------------------------")]
    [Multiline(5)]
    public string multiline;

    [TextArea(3, 5)]
    public string textArea;

    [Header("---- 左クリックでコンテキストメニュー --------------------------------------")]
    [ContextMenuItem("01_Random", "RandomNumber")]
    [ContextMenuItem("02_Reset", "ResetNumber")]
    [ContextMenuItem("03_Display Serialize Object Prop", "DisplaySerializedObjectProp")]
    public int numberForContext;

    void RandomNumber() {
        numberForContext = Random.Range(0, 100);
    }

    void ResetNumber() {
        numberForContext = 0;
    }

    void DisplaySerializedObjectProp() {
        var so = new SerializedObject (Texture2D.whiteTexture);
        var pop = so.GetIterator ();
        while (pop.NextVisible (true))
            Debug.Log (pop.propertyPath); 
    }

    [Header("---- カラー --------------------------------------")]
    public Color color1 = Color.red;


    [ColorUsage(false)]
    public Color color2 = Color.yellow;

    [ColorUsage(true, true, 0, 8, 0.125f, 3)]
    public Color color3 = Color.cyan;


    [Header("---- スペース --------------------------------------")]
    [Space(16)]
    public string spaceTest;


    [Header("---- シリアライズしたデータの変数名を変えるときに使うやつ --------------------------------------")]
    [SerializeField]
    [FormerlySerializedAs("hoge")] // これを使うとhogeでシリアライズされるので、fugaの名前を変えても大丈夫。 
    // using UnityEngine.Serializationが必要です。;
    string fuga;

    // クラス宣言の上に[ExecuteInEditMode] をつけているので、以下はEditor上でも実行される。
    void Awake() {
        // Debug.Log("Awake by DefaultEditorExtendCheck !!");
    }

    void Start() {
        // Debug.Log("Start by DefaultEditorExtendCheck !!");
    }

    void Update() {
        // Debug.Log("Update by DefaultEditorExtendCheck !!");
    }


    [ContextMenu("ExecuteByContextMenu")]
    void ExecuteByContextMenu() {
        Debug.Log("Written by ExecuteByContextMenu Line 1\nWritten by ExecuteByContextMenu Line 2");
    }
}