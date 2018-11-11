using UnityEngine;

public class PortalCollider : MonoBehaviour
{

    public Transform destination;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CameraController.instance.teleportCam = true;

            Vector3 newEulerRotation = destination.eulerAngles;
            newEulerRotation.x = 0f;
            newEulerRotation.y = newEulerRotation.y + 90f;
            newEulerRotation.z = 0f;
            other.transform.eulerAngles = newEulerRotation;

            Vector3 newPosition = new Vector3(
                destination.position.x,
                other.transform.position.y,
                destination.position.z
            ) + destination.right * 1.05f;
            other.transform.position = newPosition;
            StartCoroutine(CameraController.instance.MoveAfterTeleport(1f));
        }
    }
}
