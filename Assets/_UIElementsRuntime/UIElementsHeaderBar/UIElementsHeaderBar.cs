using Unity.UIElements.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class UIElementsHeaderBar : PanelRenderer {
    public void Start() {
        base.Start();
        var testButton = visualTree.Q<Button>("service-title");
        if (testButton != null) {
            testButton.clickable.clicked += () => { Debug.Log("button clicked"); };
        }
    }
}