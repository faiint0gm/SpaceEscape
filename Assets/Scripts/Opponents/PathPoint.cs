using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<Patrol>().enabled)
            {
                other.gameObject.GetComponent<OpponentController>().actualAngle = transform.rotation.y;
                StartCoroutine(other.gameObject.GetComponent<OpponentController>().Rotate());
            }
        }
    }


}
