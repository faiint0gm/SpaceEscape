using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Teleport))]
public class TeleportTargetHandle : Editor {

    protected virtual void OnSceneGUI () {
        Teleport teleport = (Teleport)target;

        EditorGUI.BeginChangeCheck();
        Handles.color = Color.magenta;
        Vector3 teleportDestination = Handles.FreeMoveHandle(
            teleport.Destination, 
            Quaternion.identity, 
            0.3f, 
            Vector3.one, 
            Handles.SphereHandleCap
        );

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(teleport, "Change teleport destination.");
            teleport.Destination = new Vector3(
                    Mathf.Round(teleportDestination.x),
                    Mathf.Round(teleport.Destination.y),
                    Mathf.Round(teleportDestination.z)
                );
        }
    }
}
