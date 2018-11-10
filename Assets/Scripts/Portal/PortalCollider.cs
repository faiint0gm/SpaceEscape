using UnityEngine;

public class PortalCollider : MonoBehaviour
{

    public Transform destination;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CameraController.instance.teleportCam = true;
            Debug.Log(destination.rotation);
            other.transform.rotation = destination.rotation * Quaternion.Euler(0, 90, 0);
            other.transform.position = destination.position + destination.right * 1f;
            StartCoroutine(CameraController.instance.MoveAfterTeleport(1));
        }
    }
}
