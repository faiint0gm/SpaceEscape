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
            other.transform.position = Destination;
        }
    }

}
