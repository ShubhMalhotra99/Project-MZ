using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // This script handles the Basic player movement, jump, sprint, crouch and the aim system

    public float moveSpeed = 5f;
    public float sprintSpeedMultiplier = 1.5f;
    public float crouchSpeedMultiplier = 0.5f;
    public float jumpForce = 5f;
    public float crouchHeight = 0.5f;
    public float standingHeight = 1f;

    private Rigidbody rb;
    private Vector3 movement;
    private bool Isgrounded;
    private bool Issprinting;
    private bool Iscrouching;

    public Camera camera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        // remove the visibility of cursor
        Cursor.visible = false;
    }

    private void Update()
    {
        // Calculate position of mouse in world and look in the direction of mouse (aim in the direction of mouse)
        Ray camRay = camera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(camRay, out rayLength))
        {
            Vector3 pointToLook = camRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        // Read movement input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        movement = new Vector3(moveX, 0f, moveZ).normalized;

        // input for sprinting
        Issprinting = Input.GetKey(KeyCode.LeftShift);

        // input for crouching
        Iscrouching = Input.GetKey(KeyCode.C);

        // input for jumping
        if (Input.GetButtonDown("Jump") && Isgrounded)
        {
            // on input play the fuction for jumping(done for no wierd input lag)
            Jump();
        }
    }

    private void FixedUpdate()
    {
        // Apply movement
        float currentMoveSpeed = moveSpeed;

        if (Issprinting)
        {
            currentMoveSpeed *= sprintSpeedMultiplier;
        }

        if (Iscrouching)
        {
            currentMoveSpeed *= crouchSpeedMultiplier;
            SetPlayerHeight(crouchHeight);
        }
        else
        {
            SetPlayerHeight(standingHeight);
        }

        Vector3 movementVelocity = movement * currentMoveSpeed * Time.fixedDeltaTime;
        Move(movementVelocity);
    }

    private void Jump()
    {
        // add upward force on the input and jump
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void Move(Vector3 movementVelocity)
    {
        Vector3 newPosition = rb.position + movementVelocity;
        rb.MovePosition(newPosition);
    }

    private void SetPlayerHeight(float height)
    {
        Vector3 newScale = transform.localScale;
        newScale.y = height;
        transform.localScale = newScale;
    }

    private void OnCollisionStay(Collision collision)
    {
        // Check to see if player is on ground
        Isgrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check to see if player is on ground
        Isgrounded = false;
    }

    // Script Made by Shubh Malhotra
}
