using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Togglable))]
public class TogglableEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ITogglable togglable = (ITogglable)target;
        if (GUILayout.Button("Toggle"))
        {
            togglable.Toggle();
        }
    }
}
