using System;
using UnityEngine;
using System.Collections;
using System.Text;
using Cinemachine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GravityBodyNewMultiplayer))]
public class FirstPersonControllerMultiplayer : NetworkBehaviour
{
    // public vars
    public float mouseSensitivityY = 1;
    public float walkSpeed = 6;
    public float jumpForce = 220;
    public LayerMask groundedMask;
    public SceneManagerMultiplayer sceneManager;
    public CinemachineVirtualCamera virtualCamera;
    
    // private vars
    private NetworkVariable<float> time = new NetworkVariable<float>(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    // System vars
    bool grounded = true;
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    float verticalLookRotation;
    //Transform cameraTransform;
    Rigidbody rigidbody;
    private Vector2 maxFollowoffset = new Vector2(-1f, 3f);
    private CinemachineTransposer transposer;

    /* TODO
     - check collision with other players, if so, enable UI.
     
     */
    

    void Awake()
    {
        sceneManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneManagerMultiplayer>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //cameraTransform = Camera.main.transform;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (sceneManager.IsPlaying())
        {
            if (IsClient && !IsHost)
            {
                time.Value += Time.deltaTime;
            }
            //Doesn't execute anything if client isn't owner of the script, prevents other players from controlling your character
            if (!IsOwner)
            {
                return;
            }
            // Calculate movement, rotation and Jump Vectors:
            CameraRotation();
            Move();
            Jump();
        }
    }

    private void CameraRotation()
    {
        /*
        verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -40, -10);
        cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation;
        */

    /*
        float followOffset = Mathf.Clamp(transposer.m_FollowOffset.y - 
                                         (Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime),
            maxFollowoffset.x, maxFollowoffset.y);
        transposer.m_FollowOffset.y = followOffset;
        */
    }

    private void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rigidbody.AddForce(transform.up * jumpForce);
                grounded = false;
            }
        }
    }
    
    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            virtualCamera.gameObject.SetActive(true);
            enabled = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Planet"))
        {
            grounded = true;
        }

        if (other.gameObject.CompareTag("Player") && IsClient)
        {
            sceneManager.GameOver(time.Value);
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