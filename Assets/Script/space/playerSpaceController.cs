using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerSpaceController : MonoBehaviour, Space_control.ISpaceControlActions
{
    public Rigidbody2D rb;
    public float moveSpeed;
    private Vector2 moveInput;
    public float rotationSpeed;
    
    // dash
    public float dashTime = 0.2f;
    private float dashTimer = -1;
    public float dashSpeed = 3.0f;
    public float dashCDTime = 1.0f;
    private float dashCDTimer = 0;
    public float normalspeed = 100.0f;
    public float maxSpeed = 100.0f;

    public Space_control controls;

    private void Awake()
    {
        controls = new Space_control();
        controls.SpaceControl.SetCallbacks(this);
    }
    
    void Start()
    {
        controls.Enable();
    }
    
    void Update()
    {
        // dash speed time
        if (dashTimer > 0)
            dashTimer -= Time.deltaTime;
        else if (dashTimer < 0)
        {
            maxSpeed = normalspeed;
            dashTimer = 0;
        }
        
        // dash cooldown
        if (dashCDTimer > 0)
            dashCDTimer -= Time.deltaTime;
        else if (dashCDTimer < 0)
            dashCDTimer = 0;
    }

    void LateUpdate()
    {
        if (moveInput.y != 0)
        {
            moveSpeed = Mathf.Clamp(moveSpeed + moveInput.y, -maxSpeed, maxSpeed);
            rb.velocity = (moveSpeed * transform.up);
        }
        rb.angularVelocity = moveInput.x * rotationSpeed;
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (dashCDTimer != 0)
            return;
        if (context.performed)
        {
            maxSpeed *= dashSpeed;
            moveSpeed = maxSpeed;
            dashTimer = dashTime;
            dashCDTimer = dashCDTime;
        }
    }

    public void OnShield(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
