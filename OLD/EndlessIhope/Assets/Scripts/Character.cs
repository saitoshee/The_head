using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Unit {

	[SerializeField]
	private float speed = 7.0f;

	[SerializeField]
	private int lives = 3;

	[SerializeField]
	private float jumpForce = 11.0f;

	//initialization of links on components
	new private Rigidbody2D rigidbody;
	private Animator animator; 
	private SpriteRenderer sprite; 

	// Field for stop infinity jump
	private bool isGrounded = false;
	// Field for loading bullets
	private Bullet bullet;

	private void Awake()
	{	//gets links
		rigidbody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		sprite = GetComponentInChildren<SpriteRenderer> ();

		bullet = Resources.Load<Bullet> ("Bullet");
	}

	private void FixedUpdate()
	{
		checkGround ();
	}

	private void Update()
	{

		//When call the methods
		if (Input.GetButton("Horizontal")) 
			Run();
		if (isGrounded && Input.GetButtonDown ("Jump"))
			Jump ();
	
	}

	private void Run()
	{	
		Vector3 direction = transform.right * Input.GetAxis ("Horizontal");		//creating local var; return -1 or 1 (lefr or right)

		// move for Character
		transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime); // the distance is speed * time btw last and now frame

		sprite.flipX = direction.x < 0.0f;; // return true or false; link on Flip component


	}

	private void Jump()
	{
		rigidbody.AddForce (transform.up * jumpForce, ForceMode2D.Impulse); // 
		
	}

	private void checkGround() // check for collder under Character
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);

		isGrounded = colliders.Length > 1; // if method in arr returned more 1 it is mean Character on ground

	}

}
	

/*
 * [SerializeField] - Force to serialize a private field
 * Animator - Interface to controll the Mecanim animation sys
 * SpriteRenderer -  Renders a sprite for 2D
 * Input.GetAxis - Returns the value of the virtual axis identified by axisName(Ex: Horizontal || all list: Settings - Input)
 * Vecotr3.MoveTowards(from,where, what distance will pass in one frame) - Moves a point current in a straight line towards a target point.
 * AddForce(where,method for force) - Can apply a force to the rigidbody.
 * ForceMode2D.Impulse\Forse - method for force
 * Physics2D.OverlapCircleAll - Get a list of all colliders that fall within a circular area.but this will allocate memory for the array.
 * Physics2D.OverlapCircleNonAlloc - just;
 * 25/01 - wow it is works yet!
*/