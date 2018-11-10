using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour {

    public static OpponentController instance;

    [Header("Rotation Config")]
    [Range(0,359)]
    public float minAngle = 0;
    [Range(0,359)]
    public float maxAngle = 1;
    [Range(0,1)]
    public float rotationSpeed;

    bool increasing;
    float actualAngle;
    float rotationMultiplier;
    void Awake()
    {
        if(minAngle>maxAngle)
        {
            Debug.LogError("Minimum angle has to be smaller or equal to Maximum angle! QUTING!");
            Application.Quit();
        }

        instance = this;
        rotationMultiplier = 100;
        transform.rotation = Quaternion.Euler(0, minAngle, 0);
        actualAngle = minAngle;
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    void CheckIncreasing()
    {
        if(actualAngle <= minAngle && !increasing)
        {
            increasing = true;
        }
        else if (actualAngle >= maxAngle && increasing)
        {
            increasing = false;
        }
    }

    void Rotate()
    {
        CheckIncreasing();
        if (increasing)
        {
            actualAngle += rotationSpeed * rotationMultiplier *Time.deltaTime;
        }
        else
            actualAngle -= rotationSpeed * rotationMultiplier * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, actualAngle, 0);
    }


}
