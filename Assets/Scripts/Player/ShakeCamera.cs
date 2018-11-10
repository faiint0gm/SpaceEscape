using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour {


    // How long the object should shake for.
    public float shakeDuration = 0.3f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;
    public bool shaketrue = false;


    void OnEnable()
    {
        originalPos = transform.localPosition;
    }

    void Update()
    {
        if (shaketrue)
        {
            if (shakeDuration > 0)
            {
                transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakeDuration = 1f;
                transform.localPosition = originalPos;
                shaketrue = false;
            }
        }
    }

    public void Shakecamera()
    {
        shaketrue = true;
    }

}
