using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.TouchPhase;

public class PlayerMovementBehavior : MonoBehaviour
{
    //private Rigidbody playerRb;
    public CharacterController controller;

    public Rigidbody playerRb;


    public InputAction playerControls;

    public Transform cam;

    public float speed = 6f;
    public float turnSpeed = 10;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    //public float rotationSpeed;
    //public float moveSpeed;

    //void Start()
    //{
    //    playerRb = gameObject.GetComponent<Rigidbody>();
    //}

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = turnSpeed;
    
        //var movementDirection = playerControls.ReadValue<Vector3>();
    
            
            
        //Allows the player to move in all directions on a 2d plane
        //playerRb.AddForce(Vector3.forward * (moveSpeed * verticalInput * Time.deltaTime));
        playerRb.AddForce(Vector3.right * ((speed + speed) * horizontalInput * Time.deltaTime));
    
        var movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
    
        if (movementDirection.magnitude >= 0.1f)
        {
            var toRotation = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, toRotation, ref turnSmoothVelocity,
                turnSmoothTime);
                
            transform.rotation = Quaternion.Euler(0f, angle, 0f * Time.deltaTime);
                
            Vector3 moveDir = Quaternion.Euler(0f, toRotation, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * (speed * Time.deltaTime));
        }

    }
}
