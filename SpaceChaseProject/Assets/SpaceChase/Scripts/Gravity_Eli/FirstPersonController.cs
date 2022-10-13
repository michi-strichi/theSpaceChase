using System;
using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GravityBody))]
public class FirstPersonController : MonoBehaviour
{
    // public vars
    public float mouseSensitivityY = 1;
    public float walkSpeed = 6;
    public float jumpForce = 220;
    public LayerMask groundedMask;
    public SceneManagerSingleplayer sceneManager;

    // System vars
    bool grounded = true;
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    float verticalLookRotation;
    Transform cameraTransform;
    Rigidbody rigidbody;


    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cameraTransform = Camera.main.transform;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (sceneManager.IsPlaying())
        {
                  
            verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -40, -10);
            cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation;
        
        
            // Calculate movement:
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");

            Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
            Vector3 targetMoveAmount = moveDir * walkSpeed;
            moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);


            // Jump
            if (Input.GetButtonDown("Jump"))
            {
                if (grounded)
                {
                    rigidbody.AddForce(transform.up * jumpForce);
                    grounded = false;
                }
            }
        }
  
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Planet"))
        {
            grounded = true;
        }
    }

    void FixedUpdate()
    {
        if (sceneManager.IsPlaying())
        {
            // Apply movement to rigidbody
            Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
            rigidbody.MovePosition(rigidbody.position + localMove);
        }

    }
}