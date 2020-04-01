using UnityEngine;

[ExecuteInEditMode] // ゲーム再生中でなくても MonoBehaviour の主要な関数が呼び出されるようになります。
public class UIElementCustomEditorTestObject : MonoBehaviour {
    [SerializeField] private string account = "0";
    [SerializeField] private string password = "0";

    public void Connect1() {
        Debug.Log("connect1");
    }

    public void Connect2() {
        Debug.Log("connect2");
    }
    
    public void Connect3() {
        Debug.Log("connect3");
    }

    void Start() {
        account = (int.Parse(account) + 1).ToString();
        password = (int.Parse(password) + 2).ToString();
    }

    void Update() {
        Debug.Log(account + " " + password);
    }
}