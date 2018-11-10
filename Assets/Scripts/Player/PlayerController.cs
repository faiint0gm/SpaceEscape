using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Range(100,300)]
    public float rotationSpeed;

    [Range(1,10)]
    public float movementSpeed;

    private void Update()
    {
        CheckMovement();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Interact();
    }

    void CheckMovement()
    {
        float translation = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        float rotation = rotationSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(0, 0, translation);
        }
        else
            transform.Translate(0, 0, 0);
    }

    void Interact()
    {
        Debug.Log("Interaction");
    }
}
