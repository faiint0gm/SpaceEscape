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

        Quaternion entryRotation = Handles.RotationHandle(
            entry.rotation,
            entry.position
        );

        Quaternion exitRotation = Handles.RotationHandle(
            exit.rotation,
            exit.position
        );

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(portal, "Change entry destination.");
            entry.position = new Vector3(
                    Mathf.Round(entryDestination.x / 0.5f) * 0.5f,
                    0,
                    Mathf.Round(entryDestination.z / 0.5f) * 0.5f
                );
            exit.position = new Vector3(
                    Mathf.Round(exitDestination.x / 0.5f) * 0.5f,
                    0,
                    Mathf.Round(exitDestination.z / 0.5f) * 0.5f
                );

            Vector3 entryEuler = entryRotation.eulerAngles;
            entryEuler.x = 0f;
            entryEuler.y = roundTo90(entryEuler.y);
            entryEuler.z = 0f;
            entry.eulerAngles = entryEuler;

            Vector3 exitEuler = exitRotation.eulerAngles;
            exitEuler.x = 0f;
            exitEuler.y = roundTo90(exitEuler.y);
            exitEuler.z = 0f;
            exit.eulerAngles = exitEuler;
        }
    }

    private float roundTo90 (float angle)
    {
        if (angle >= 45f && angle < 135f)
        {
            return 90f;
        }
        else if (angle >= 135f && angle < 225f)
        {
            return 180f;
        }
        else if (angle >= 225f && angle < 315f)
        {
            return 270f;
        } else
        {
            return 0f;
        }
    }
}
