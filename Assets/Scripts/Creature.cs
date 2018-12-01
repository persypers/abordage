using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour {
	public static float gravity = 20f;
	public float speed = 1.0f;
	float horDir = 1.0f;
	new Rigidbody rigidbody;
	CharacterController controller;
	Animator animator;
	Vector3 prevMove;
	public float moveControl = 1f;
	public Vector3 Move;
	HP hp;
	public int hitRecoveries = 1;
	public int deaths = 1;
	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();
		hp = GetComponent<HP>();
		hp.OnDamage.AddListener((damage) => {animator.SetTrigger("hitRecovery" + Random.Range(0, hitRecoveries));});
		hp.OnDeath.AddListener((damage) => {
			animator.SetTrigger("death" + Random.Range(0, deaths));
			controller.enabled = false;
			enabled = false;
		});
	}
	private void Update()
	{
		float rotation = (Input.GetKey(KeyCode.Q) ? -1.0f : 0.0f) + (Input.GetKey(KeyCode.E) ? 1.0f : 0);
		Vector3 eul = transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler(eul.x, eul.y + rotation * 2f, eul.z);

		animator.SetBool("isGrounded", controller.isGrounded);
		Vector3 move = controller.isGrounded ? Vector3.zero : prevMove;
		move += Move * moveControl;
		if(moveControl > 0f)
		{
			float dir = Vector3.Dot(move, Camerizer.Instance.Right);
			if(dir != 0f && Mathf.Sign(dir) != horDir) Flip();
			animator.SetFloat("speed", move.sqrMagnitude);
		}
		move.y -= gravity * Time.deltaTime;
		prevMove = move;
		controller.Move(move * Time.deltaTime);
	}

	private void Flip()
	{
		horDir *= -1;
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.y);
	}
}
