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
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			self.Jump = true;
		}

		self.Move = move;

		if(Input.GetKeyDown(KeyCode.F)) self.Attack();
	}
}
