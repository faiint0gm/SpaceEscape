using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentController : MonoBehaviour {

    [Header("Rotation Config")]
    [Range(0,359)]
    public float minAngle = 0;
    [Range(0,359)]
    public float maxAngle = 1;
    [Range(0,1)]
    public float rotationSpeed;


    bool increasing;
    [System.NonSerialized]
    public float actualAngle;
    float rotationMultiplier;
     float angleRange;
    void Awake()
    {
        if(minAngle>maxAngle)
        {
            Debug.LogError("Minimum angle has to be smaller or equal to Maximum angle! QUTING!");
            Application.Quit();
        }

        angleRange = maxAngle - minAngle;
        rotationMultiplier = 100;
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

    public IEnumerator Rotate()
    {
        CheckIncreasing();
        float tempAngle = transform.rotation.y;

        while (actualAngle > tempAngle + minAngle)
        {
            CheckIncreasing();
            actualAngle -= rotationSpeed * rotationMultiplier * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, actualAngle, 0);
            yield return null;
        }

        while (increasing)
        {
            CheckIncreasing();
            actualAngle += rotationSpeed * rotationMultiplier *Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, actualAngle, 0);
            yield return null;
        }

        while (actualAngle >= tempAngle + angleRange * 0.5f)
        {
            CheckIncreasing();
            actualAngle -= rotationSpeed * rotationMultiplier * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, actualAngle, 0);
            yield return null;
        }

        gameObject.GetComponent<Patrol>().GotoNextPoint();
    }

}
