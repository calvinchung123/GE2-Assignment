using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Soldieranimator : MonoBehaviour
{
    float speed = 4;
    float rotspeed = 80;
    float gravity = 8;
    float rot = 0f;

    Vector3 moveDir = Vector3.zero;
    CharacterController controller;

    Animator anim;

    void start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void update()
    {
        if(controller.isGrounded)
        {
            if(Input.GetKey (KeyCode.W))
            {
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }
            if(Input.GetKeyUp (KeyCode.W))
            {
                moveDir = new Vector3(0, 0, 0);
            }
        }
        rot += Input.GetAxis("Horizontal") * rotspeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }

}
