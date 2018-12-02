using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {
	Creature self;
	public float speed;
	void Start () {
		self = GetComponent<Creature>();
	}

	public void Update()
	{
		self.controller.Move(Camerizer.Instance.Right * self.horDir * speed * Time.deltaTime);
	}

	public void OnDisabled()
	{
		self.controller.Move(new Vector3(0f, Creature.gravity * Time.deltaTime, 0f));
		self.animator.SetBool("isGrounded", true);
	}
}
