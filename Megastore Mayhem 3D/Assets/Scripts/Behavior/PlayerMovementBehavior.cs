using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{
    public CharacterController controller;
    
    public Transform cam;

    public float speed;
    public float turnSpeed = 10;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    

    void Update()
    {
        var verticalInput = turnSpeed;
        //float horizontalInput = 0;

        var mousePos = Camera.main.ViewportToScreenPoint(Input.mousePosition).normalized;

        var movementDirection = new Vector3(0, 0, verticalInput).normalized;

        var toRotation = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg +
                         cam.eulerAngles.y;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, toRotation, ref turnSmoothVelocity,
            turnSmoothTime);
        
        Vector3 moveDir = Quaternion.Euler(0f, toRotation, 0f) * Vector3.forward;
        controller.Move(moveDir.normalized * (speed * Time.deltaTime));
        
        if (Input.GetMouseButton(0))
        {
            if (mousePos.x > 0.99)
            {
                //Debug.Log("Mouse down right");
                var horizontalInput = 1;

                //playerRb.AddForce(Vector3.right * ((speed + speed) * horizontalInput * Time.deltaTime));
                movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

                if (movementDirection.magnitude >= 0.1f)
                {
                    toRotation = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg +
                                 cam.eulerAngles.y;
                    angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, toRotation, ref turnSmoothVelocity,
                        turnSmoothTime);

                    transform.rotation = Quaternion.Euler(0f, angle, 0f * Time.deltaTime);

                    moveDir = Quaternion.Euler(0f, toRotation, 0f) * Vector3.forward;
                    controller.Move(moveDir.normalized * (speed * Time.deltaTime));
                }
            }

            else if (mousePos.x < 0.99)
            {
                //Debug.Log("Mouse down left");
                var horizontalInput = -1;

                //playerRb.AddForce(Vector3.right * ((speed + speed) * horizontalInput * Time.deltaTime));
                
                movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

                if (movementDirection.magnitude >= 0.1f)
                {
                    toRotation = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg +
                                 cam.eulerAngles.y;
                    angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, toRotation, ref turnSmoothVelocity,
                        turnSmoothTime);
                    transform.rotation = Quaternion.Euler(0f, angle, 0f * Time.deltaTime);

                    moveDir = Quaternion.Euler(0f, toRotation, 0f) * Vector3.forward;
                    controller.Move(moveDir.normalized * (speed * Time.deltaTime));
                }
            }
        }
    }

    public void SetSpeed(float num)
    {
        speed = num;
    }
}
