using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
	[SerializeField] private float speed = 50f;
	[SerializeField] private int lives = 5;
	[SerializeField] private float  jumpForce = 15f; 
	
	private bool isGrounded = false;

	private Rigidbody2D rd;
	private SpriteRenderer sprite;



	private void Awake()
	{
		rd = GetComponent<Rigidbody2D>();
		sprite = GetComponentInChildren<SpriteRenderer>();
	}


	private void Update()
	{
		if (Input.GetButton("Horizontal"))
			Run();

		if (Input.GetButtonDown("Jump"))
			Jump();
	}


	private void Run()
	{
		Vector3 dir = transform.right * Input.GetAxis("Horizontal");

		transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

		sprite.flipX = dir.x < 0.0f;
	}

	private void Jump()
	{
		rd.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
	}

	
}
