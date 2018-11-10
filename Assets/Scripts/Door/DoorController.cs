using UnityEngine;

public class DoorController : MonoBehaviour {
    
    public GameObject forceField;

    public bool IsOpen {
        get { return m_isOpen; }
        set {
            m_isOpen = value;
            forceField.SetActive(value);
        }
    }

    [SerializeField]
    private bool m_isOpen = false;
}
