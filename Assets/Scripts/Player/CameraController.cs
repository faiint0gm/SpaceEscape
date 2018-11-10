using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public Vector3 targetPositionOffset = new Vector3(21.3f,30,0);
    public float smooth = 0.05f;

    Vector3 targetPos = Vector3.zero;
    Vector3 destination = Vector3.zero;

    private void Start()
    {
        SetCameraTarget(target);

        MoveToTarget();
    }

    private void FixedUpdate()
    {
        //moving
        MoveToTarget();
        LookAtTarget();
    }

    void SetCameraTarget(Transform t)
    {
        target = t;

        if (target == null || !target.GetComponent<PlayerController>())
        {
            Debug.LogError("The target needs a PlayerController script!");
        }
    }

    void MoveToTarget()
    {
        targetPos = target.position + targetPositionOffset;
        transform.position = targetPos;
    }

    void LookAtTarget()
    {
        transform.LookAt(target);
    }
}
