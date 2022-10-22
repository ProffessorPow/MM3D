using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{
    private Rigidbody playerRb;

    public float rotationSpeed;
    public float moveSpeed;
    
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        //Allows the player to move in all directions on a 2d plane
        playerRb.AddForce(Vector3.forward * moveSpeed * verticalInput * Time.deltaTime);
        playerRb.AddForce(Vector3.right * moveSpeed * horizontalInput * Time.deltaTime);

        var movementDirection = new Vector3(horizontalInput, 0, verticalInput);

        if (movementDirection != Vector3.zero)
        {
            var toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        
    }

   

}
