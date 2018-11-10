using UnityEngine;

public class Togglable : MonoBehaviour, ITogglable
{
    public GameObject toggleTarget;

    public void Toggle()
    {
        IsActive = !IsActive;
    }

    public void SetActive(bool active)
    {
        IsActive = active;
    }

    public bool IsActive
    {
        get { return m_isActive; }
        set
        {
            m_isActive = value;
            toggleTarget.SetActive(value);
        }
    }

    private bool m_isActive = true;
}
