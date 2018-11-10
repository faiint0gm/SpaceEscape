using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Animator anim;

    [Range(100,300)]
    public float rotationSpeed;

    [Range(1,10)]
    public float movementSpeed;

    float direction;
    private void Start()
    {
        anim = GetComponent<Animator>();
        direction = 0;
    }

    private void FixedUpdate()
    {
        if(!CameraController.instance.teleportCam)
            CheckMovement();
    }

    void CheckMovement()
    {

        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            anim.SetBool("isWalking", false);
            transform.Translate(0, 0, 0);
        }
        else
        {
            anim.SetBool("isWalking", true);
            Move(Pos(Input.GetAxisRaw ("Vertical"), Input.GetAxisRaw("Horizontal")));
        }
    }

    void Interact()
    {
        Debug.Log("Interaction");
    }

    int Pos(float ver, float hor)
    {
        int pos = -1;
        if (ver > 0 && hor == 0)
            pos = 0;
        else if (ver < 0 && hor == 0)
            pos = 1;
        else if (ver == 0 && hor > 0)
            pos = 2;
        else if (ver == 0 && hor < 0)
            pos = 3;
        else if (ver > 0 && hor > 0)
            pos = 4;
        else if (ver < 0 && hor > 0)
            pos = 5;
        else if (ver < 0 && hor < 0)
            pos = 6;
        else if (ver > 0 && hor < 0)
            pos = 7;
        return pos;
    }

    void Move(int position)
    {
        float translationVer = Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime;
        float translationHor = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;

        switch (position)
        {
            case 0:
                direction = 0;
                transform.rotation = Quaternion.Euler(0, direction, 0);
                transform.Translate(0, 0, translationVer);
                break;
            case 1:
                direction = 180;
                transform.rotation = Quaternion.Euler(0, direction, 0);
               transform.Translate(0, 0, -translationVer);
                break;
            case 2:
                direction = 90;
                transform.rotation = Quaternion.Euler(0, direction, 0);
                transform.Translate(0, 0, translationHor);
                break;
            case 3:
                direction = 270;
                transform.rotation = Quaternion.Euler(0, direction, 0);
                transform.Translate(0, 0, -translationHor);
                break;
            case 4:
                direction = 45;
                transform.rotation = Quaternion.Euler(0, direction, 0);
                transform.Translate(0, 0, translationVer);
                break;
            case 5:
                direction = 135;
                transform.rotation = Quaternion.Euler(0, direction, 0);
                transform.Translate(0, 0, -translationVer);
                break;
            case 6:
                direction = 225;
                transform.rotation = Quaternion.Euler(0, direction, 0);
                transform.Translate(0, 0, -translationVer);
                break;
            case 7:
                direction = 315;
                transform.rotation = Quaternion.Euler(0, direction, 0);
                transform.Translate(0, 0, translationVer);
                break;
        }
    }
}
