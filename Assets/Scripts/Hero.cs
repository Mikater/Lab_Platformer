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
  	private Animator anim;
	private SpriteRenderer sprite;
	
	
	private void Awake()
	{
		rd = GetComponent<Rigidbody2D>();
    		anim = GetComponent<Animator>();
		sprite = GetComponentInChildren<SpriteRenderer>();
	}


	private void Update()
	{

		if (Input.GetButton("Horizontal"))
			Run();

		if (Input.GetButtonDown("Jump"))
			Jump();

    		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
    			{
      				anim.SetBool("run", true);
    			}  
    			else 
    			{
     			 anim.SetBool("run", false);
    			}
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

	public void RecountHP(int deltaHp)
	{
		lives += deltaHp;
		print(lives);
		if (lives <= 0)
		{
			print("—мерть."); //зам≥сть пр≥нта, зм≥на сцени)
		}
	}

}
