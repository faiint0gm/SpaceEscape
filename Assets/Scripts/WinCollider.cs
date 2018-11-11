using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCollider : MonoBehaviour {


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
            WinLevel();
        else
            Debug.Log("Something else triggered");
    }

    public void WinLevel ()
    {
        GameManager.isWin = true;
    }
}
