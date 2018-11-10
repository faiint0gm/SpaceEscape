using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Teleport))]
public class TeleportTargetHandle : Editor {

    protected virtual void OnSceneGUI () {
        Teleport teleport = (Teleport)target;

        float size = HandleUtility.GetHandleSize(teleport.destination) * 0.3f;

        EditorGUI.BeginChangeCheck();
        Handles.color = Color.magenta;
        Vector3 teleportDestination = Handles.FreeMoveHandle(teleport.destination, Quaternion.identity, size, Vector3.one, Handles.SphereHandleCap);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(teleport, "Change teleport destination.");
            teleport.destination = new Vector3(
                    Mathf.Round(teleportDestination.x),
                    Mathf.Round(teleport.destination.y),
                    Mathf.Round(teleportDestination.z)
                );
        }
    }
}
