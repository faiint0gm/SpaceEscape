using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour, IInteractable {

    public void Activate ()
    {
        Debug.Log("Switch activated");
    }
}
