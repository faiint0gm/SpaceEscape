using System;
using UnityEngine;

[Serializable]
public class Target
{
    public GameObject obj;
    public bool positive;
}

public class SwitchController : MonoBehaviour, IInteractable {

    public Target[] targets;
    public Material lights;
    private bool m_isActive = false;

    public void Activate ()
    {
        m_isActive = !m_isActive;

        if (m_isActive)
        {
            lights.EnableKeyword("_EMISSION");
        } else
        {
            lights.DisableKeyword("_EMISSION");
        }

        foreach (Target item in targets)
        {
            item.obj.GetComponent<Togglable>().SetActive(m_isActive ? item.positive : !item.positive);
        }
    }
}
