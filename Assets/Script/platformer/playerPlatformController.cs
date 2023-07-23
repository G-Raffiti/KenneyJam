
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerPlatformController : MonoBehaviour, Space_control.ISpaceControlActions
{
	public Rigidbody2D rb;
	public Transform groundCheck;
	public LayerMask groundLayer;

	private float horizontal;
	public float speed = 1f;
	public float jumpingPower = 5f;
	public float bumpingPower = 7f;
	public bool isFacingRight = true;

	private Space_control controls;
	public bool has_control = true;

	public AudioSource audio;

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
		if (!isFacingRight && horizontal > 0f)
		{
			Flip();
		}
		else if (isFacingRight && horizontal < 0f)
		{
			Flip();
		}
	}

	private void FixedUpdate()
	{
		if (IsGrounded() && rb.velocity.x != 0 && !audio.isPlaying)
			audio.Play();
		else
			audio.Stop();
		rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
	}

	public bool IsGrounded()
	{
		return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
	}

	private void Flip()
	{
		isFacingRight = !isFacingRight;
		Vector3 localScale = transform.localScale;
		localScale.x *= -1f;
		transform.localScale = localScale;
	}
	
	public void OnMovement(InputAction.CallbackContext context)
	{
		if (!has_control) return;
		horizontal = context.ReadValue<Vector2>().x;
		
		if (context.ReadValue<Vector2>().y > 0)
		{
			OnDash(context);
		}
	}

	public void OnDash(InputAction.CallbackContext context)
	{
		if (!has_control) return;
		if (context.performed && IsGrounded())
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
		}

		if (context.canceled && rb.velocity.y > 0f)
		{
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
		}
	}

	public void OnShield(InputAction.CallbackContext context)
	{
		//todo : shield
	}

	public void goBack(int direction)
	{
		has_control = false;
		horizontal = direction;
	}

	public void Bump()
	{
		rb.velocity = new Vector2(rb.velocity.x, bumpingPower);
	}

	public void OnDestroy()
	{
		controls.SpaceControl.RemoveCallbacks(this);
	}
}