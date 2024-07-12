using UnityEngine;
using UnityEngine.TextCore.Text;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
   

    public Camera mainCamera;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 10.0f;
    private float jumpHeight = 2.0f;
    private float gravityValue = -9.81f;

    void Start()
    {
        mainCamera = Camera.main;
        // get the character controller and save it in the controller variable
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {
        // Look at mouse position - creates a ray from camera to mouse position. Checks if it has hit an object up to a distance of 100 units. If it does, rotates object to face that point while keep y coord same.
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }


        // Check is player is touching ground. If they are an vertical velocity is negative (falling), set to 0 to stop falling through ground.
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }



        // Gets  horizontal and vertical input and creates a vector from it. Move based on vector, and time since last frame, and speed. If player is moving, rotates object in direction of movement.
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //player movement based on position of camera, not world coordinates
        Vector3 move = mainCamera.transform.forward * Input.GetAxis("Vertical") + mainCamera.transform.right * Input.GetAxis("Horizontal");
        controller.Move(move * Time.deltaTime * playerSpeed);


        //keep this if oyu want character to lean forward when moving
        //if (move != Vector3.zero)
        //{
            //gameObject.transform.forward = move;
        //    gameObject.transform.forward = mainCamera.transform.forward;
        //}


        // Jumping. If space is pressed, and player on ground, set vertical velocity to a value that will make them jump to a height. 3 to make it move gamey/floaty.
        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }


        // Updates players vertical velocity based on gravity and amount of time passed since last frame. Then move player based on velocity.
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }



}

