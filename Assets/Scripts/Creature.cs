using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Creature : MonoBehaviour {
	[System.Serializable]
	public struct State
	{
		public bool canMove;
		public bool hitRecovery;
		public bool canAttack;
		public bool canJump;
		public float moveControl;
		public State (bool canMove = true, bool hitRecovery = true, bool canAttack = true, bool canJump = true, float moveControl = 1f)
		{
			this.canMove = canMove;
			this.hitRecovery = hitRecovery;
			this.canAttack = canAttack;
			this.canJump = canJump;
			this.moveControl = moveControl;
		}
	}
	public State state = new State();
	public static float gravity = 20f;
	public float speed = 1.0f;
	public float jumpSpeed;
	float horDir = 1.0f;
	new Rigidbody rigidbody;
	public CharacterController controller;
	Animator animator;
	public Vector3 Move;
	public Vector3 prevMove;
	public bool Jump;
	HP hp;
	public int hitRecoveries = 1;
	public int deaths = 1;
	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		if(!controller) controller = GetComponent<CharacterController>();
		hp = GetComponent<HP>();
		hp.OnDamage.AddListener((damage) => {
			if(state.hitRecovery) animator.SetTrigger("hitRecovery" + Random.Range(0, hitRecoveries));
		});
		hp.OnDeath.AddListener((damage) => {
			state.hitRecovery = false;
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
		if(state.canMove)
		{
			move += Move.normalized * speed * state.moveControl;
			//Vector3 vertSpeed = new Vector3(0f, move.y, 0f);
			move = move.normalized * speed;
			float dir = Vector3.Dot(move, Camerizer.Instance.Right);
			if(dir != 0f && Mathf.Sign(dir) != horDir) Flip();
			animator.SetFloat("speed", move.sqrMagnitude);
		}
		move.y -= gravity * Time.deltaTime;

		if(Jump && state.canJump)
		{
			move.y = jumpSpeed;
			animator.SetTrigger("jump");
			animator.SetFloat("speed", 0);
		}
		Jump = false;

		prevMove = move;
		controller.Move(move * Time.deltaTime);
	}

	public void Attack()
	{
		if(state.canAttack)
		{
			animator.SetTrigger("attack");
		}
	}

	private void Flip()
	{
		horDir *= -1;
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.y);
	}
}
