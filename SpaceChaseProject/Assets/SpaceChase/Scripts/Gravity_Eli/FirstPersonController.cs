using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float mouseSensX = 250.0f;
    public float mouseSensY = 250.0f;
    public float walkSpeed = 8f;
    public float jumpForce = 2200f;

    private Transform CamT;
    private float vertViewRot;
    
    private Vector3 moveAmount;
    private Vector3 smoothMoveVel;

    void Start()
    {
        CamT = Camera.main.transform;
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensX);
        vertViewRot += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensY;
        //vertViewRot = Mathf.Clamp(vertViewRot, -60.0f, 60.0f);
        CamT.localEulerAngles = Vector3.left * vertViewRot;

        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVel, 0.20f);

        if (Input.GetButtonDown("Jump"))
        {
            var rigidbody = gameObject.GetComponent<Rigidbody>();
            rigidbody.AddForce(transform.TransformDirection(transform.up) * jumpForce);
        }
    }

    private void FixedUpdate()
    {
        var rigidbody = gameObject.GetComponent<Rigidbody>();
        //changes direction from WorldSpace to LocalSpace
        rigidbody.MovePosition(rigidbody.position + transform.TransformDirection(moveAmount)*Time.fixedDeltaTime);
    }
}