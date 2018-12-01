using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScheme : MonoBehaviour {
	Creature self;
	Animator animator;
	CharacterController controller;

	private void Awake()
	{
		self = GetComponent<Creature>();
		animator = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();
	}

	private void Update()
	{
		float hor = (Input.GetKey(KeyCode.A) ? -1.0f : 0.0f) + (Input.GetKey(KeyCode.D) ? 1.0f : 0);
		float ver = (Input.GetKey(KeyCode.S) ? -1.0f : 0.0f) + (Input.GetKey(KeyCode.W) ? 1.0f : 0);

		Vector3 move = hor * Camerizer.Instance.Right + ver * Camerizer.Instance.Depth;
		move.Normalize();
		move = move * self.speed;

		if(controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
			move.y += 10f;
			animator.SetTrigger("jump");
		}

		self.Move = move;

		if(controller.isGrounded && Input.GetKeyDown(KeyCode.F)) animator.SetTrigger("attack");
	}
}
