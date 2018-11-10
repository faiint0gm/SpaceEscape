using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public static CameraController instance;

    public Transform target;
    public Vector3 targetPositionOffset = new Vector3(21.3f,30,0);
    public float smooth = 0.05f;
    public bool teleportCam;

    Vector3 desiredPos = Vector3.zero;
    Vector3 destination = Vector3.zero;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetCameraTarget(target);

        MoveToTarget();
    }

    private void FixedUpdate()
    {
        //moving
        if (!teleportCam)
        {
            MoveToTarget();
            LookAtTarget();
        }
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
        desiredPos = target.position + targetPositionOffset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smooth);
        transform.position = smoothedPos;
    }

    void LookAtTarget()
    {
        transform.LookAt(target);
    }

    public IEnumerator MoveAfterTeleport(float time)
    {
        float t = 0.0f;
        Vector3 startingPos = transform.position;
        desiredPos = target.position + targetPositionOffset;
        while (t < time)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startingPos, desiredPos, t);
            if (transform.position == desiredPos)
                break;
            yield return null;
        }
        teleportCam = false;
    }
}
