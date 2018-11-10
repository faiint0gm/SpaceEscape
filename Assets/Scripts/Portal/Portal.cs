using UnityEngine;

public class Portal : MonoBehaviour {

    public Transform entry;
    public Transform exit;

    public Transform entryWall;
    public Transform exitWall;

    public bool invertEntryWall = false;
    public bool invertExitWall = false;

    void OnDrawGizmosSelected()
    {
        Vector3 entryEuler = entryWall.localEulerAngles;
        entryEuler.y = invertEntryWall ? 180f : 0f;
        entryWall.localEulerAngles = entryEuler;

        Vector3 exitEuler = exitWall.localEulerAngles;
        exitEuler.y = invertExitWall ? 180f : 0f;
        exitWall.localEulerAngles = exitEuler;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(entryWall.position, exitWall.position);

        Gizmos.color = Color.blue;
        Gizmos.DrawCube(
            entryWall.position + entryWall.transform.right * 0.3f,
            new Vector3(0.2f, 0.2f, 0.2f)
        );
        Gizmos.DrawCube(
            exitWall.position + exitWall.transform.right * 0.3f,
            new Vector3(0.2f, 0.2f, 0.2f)
        );

        Gizmos.color = Color.red;
        Gizmos.DrawCube(
            entryWall.position + entryWall.transform.right * -0.3f,
            new Vector3(0.2f, 0.2f, 0.2f)
        );
        Gizmos.DrawCube(
            exitWall.position + exitWall.transform.right * -0.3f,
            new Vector3(0.2f, 0.2f, 0.2f)
        );
    }
}
