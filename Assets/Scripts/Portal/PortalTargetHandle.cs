using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Portal))]
public class PortalTargetHandle : Editor
{

    protected virtual void OnSceneGUI ()
    {
        Portal portal = (Portal)target;
        Transform entry = portal.entry;
        Transform exit = portal.exit;

        EditorGUI.BeginChangeCheck();

        Handles.color = Color.cyan;
        Vector3 entryDestination = Handles.PositionHandle(
            entry.position + new Vector3(0, 2f, 0),
            Quaternion.identity
        );

        Vector3 exitDestination = Handles.PositionHandle(
            exit.position + new Vector3(0, 2f, 0),
            Quaternion.identity
        );

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(portal, "Change portal destination.");
            entry.position = new Vector3(
                    Mathf.Round(entryDestination.x),
                    0,
                    Mathf.Round(entryDestination.z)
                );
            exit.position = new Vector3(
                    Mathf.Round(exitDestination.x),
                    0,
                    Mathf.Round(exitDestination.z)
                );
        }
    }
}
