using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 1.0f;

	float horDir = 1.0f;

	SpriteRenderer spriteRenderer;
	new Rigidbody rigidbody;
	Animator animator;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
		/*
		float hor = Input.GetAxis("Horizontal");
		float ver = Input.GetAxis("Vertical");
		if (hor > 0.0f) hor = 1.0f;
		else if (hor < 0.0f) hor = -1.0f;
		if (ver > 0.0f) ver = 1.0f;
		else if (ver < 0.0f) ver = -1.0f;
		*/

		float hor = (Input.GetKey(KeyCode.A) ? -1.0f : 0.0f) + (Input.GetKey(KeyCode.D) ? 1.0f : 0);
		float ver = (Input.GetKey(KeyCode.S) ? -1.0f : 0.0f) + (Input.GetKey(KeyCode.W) ? 1.0f : 0);

		if(hor != 0.0f && hor != horDir)
		{
			Flip();
			horDir = hor;
		}

		Vector2 move = new Vector2(hor, ver) * speed;
		move.Normalize();

		bool isGrounded = Mathf.Abs(rigidbody.velocity.y) < 0.01f;

		Vector3 velocity = new Vector3(move.x, rigidbody.velocity.y, move.y);
		rigidbody.velocity = velocity;
		animator.SetFloat("speed", move.sqrMagnitude);
	}

	private void Flip()
	{
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.y);
	}
}
