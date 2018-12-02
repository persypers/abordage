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
		BehaviorDesigner.Runtime.GlobalVariables.Instance.SetVariableValue("Player", self.gameObject);
	}

	private void Update()
	{
		float rotation = (Input.GetKey(KeyCode.Q) ? -1.0f : 0.0f) + (Input.GetKey(KeyCode.E) ? 1.0f : 0);
		Vector3 eul = transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler(eul.x, eul.y + rotation * 2f, eul.z);
		
		float hor = (Input.GetKey(KeyCode.A) ? -1.0f : 0.0f) + (Input.GetKey(KeyCode.D) ? 1.0f : 0);
		float ver = (Input.GetKey(KeyCode.S) ? -1.0f : 0.0f) + (Input.GetKey(KeyCode.W) ? 1.0f : 0);

		Vector3 move = hor * Camerizer.Instance.Right + ver * Camerizer.Instance.Depth;
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			self.Jump = true;
		}

		self.Move = move;

		if(Input.GetKeyDown(KeyCode.J)) self.Attack();
		if(Input.GetKeyDown(KeyCode.K)) self.Attack("dash");
	}
}
