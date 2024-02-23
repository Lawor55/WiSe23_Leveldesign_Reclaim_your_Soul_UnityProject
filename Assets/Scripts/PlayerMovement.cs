using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    //movementspeed in meters per second
    [SerializeField] private float speed = 5f;
    //jump height in meters
    //[SerializeField] private float jumpHeight = 2f;
    private float groundTime;

    [Header("Physics Settings")]
    //gravity acceleration
    [SerializeField] private float gravity = -9.81f;
    //variable for jumping velocity
    private float verticalVelocity;

    private CharacterController controller;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }
    private void Move()
    {
        //variation of official Unity documentation of CharacterController
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        //applying of gravity to the verticalVelocity        
        if (controller.isGrounded == false)
        {
            verticalVelocity = controller.velocity.y;
        }
        verticalVelocity += gravity * Time.deltaTime;
        //exchange the vertical coordinate y with the calculated vertical velocity
        move *= speed;
        move.y = verticalVelocity;
        //applies the movement of the character
        controller.Move(Time.deltaTime * move);
    }

    //private void Jump()
    //{
    //    //groundcheck might need to be extended to allow jumps while walking down stairs
    //    if (groundTime > 0 && Input.GetKey(KeyCode.Space))
    //    {
    //        groundTime = 0;
    //        //Debug.Log("Jump!");
    //        //formula to calculate the jump acceleration based on gravity and the desired jump height
    //        verticalVelocity = Mathf.Sqrt(jumpHeight * -2 * gravity);
    //    }
    //}
    private void Update()
    {
        //Jump();
        //sets ground time to 0.2 seconds to extend ground check times while walking down stairs
        if (controller.isGrounded)
        {
            groundTime = 0.2f;
        }

        if (groundTime > 0)
        {
            groundTime -= Time.deltaTime;
        }
        //resets the vertical velocity to 0 if the player touches ground and velocity is negative
        if (controller.isGrounded && verticalVelocity < 0f)
        {
            //leads to stairlike walking when walking downwards
            //verticalVelocity = 0f;

            //leads to ramp like walking when walking downwards
            verticalVelocity = -2f;
        }
        Move();
    }
}
