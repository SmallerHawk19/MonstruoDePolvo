using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ReplaceGameObject))]
public class ReplaceGameObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ReplaceGameObject replaceGameObject = (ReplaceGameObject)target;

        if (GUILayout.Button("Replace"))
        {
            replaceGameObject.Replace();
        }
    }
}
