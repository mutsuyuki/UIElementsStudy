using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UIElementsEditorWindowData/Create UIElementsEditorWindowData Instance")]
public class UIElementsEditorWindowData : ScriptableObject
{
    [SerializeField]
    private Vector3 _position = Vector3.zero;
    public Vector3 Positon => _position;

    [SerializeField]
    private Sprite[] _sprites = null;
    public Sprite[] Sprites => _sprites;
}
