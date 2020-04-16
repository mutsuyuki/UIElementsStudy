using Unity.UIElements.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class UIElementsHeaderBar : PanelRenderer {
    public void Start() {
        base.Start();
        var logoButton = visualTree.Q<Button>("service-title");
        if (logoButton != null) {
            logoButton.clickable.clicked += () => {
                Debug.Log("logo clicked");
                EditorUtility.DisplayDialog("logo clicked", "message from header", "ok");
            };
        }

        var userNameButton = visualTree.Q<Button>("user-name");
        if (userNameButton != null) {
            userNameButton.clickable.clicked += () => {
                Debug.Log("username clicked");
                EditorUtility.DisplayDialog("user name clicked", "message from header", "ok");
            };
        }
    }
}