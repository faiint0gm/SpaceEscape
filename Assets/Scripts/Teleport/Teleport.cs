using UnityEngine;

public class Teleport : MonoBehaviour {

    public Vector3 Destination {
        get { return m_destination; }
        set { m_destination = value; }
    }

    [SerializeField]
    private Vector3 m_destination;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CameraController.instance.teleportCam = true;
            other.transform.position = Destination;
            StartCoroutine(CameraController.instance.MoveAfterTeleport(3));
        }
    }

}
