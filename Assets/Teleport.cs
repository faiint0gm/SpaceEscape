using UnityEngine;

public class Teleport : MonoBehaviour {
    public Vector3 destination { get { return m_destination; } set { m_destination = value; } }
    [SerializeField]
    private Vector3 m_destination = new Vector3(1f, 0f, 0f);
}
