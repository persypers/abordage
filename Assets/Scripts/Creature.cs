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
		public bool ignoresGravity;
		public bool ignoresPushes;
		public float moveControl;
		public State (bool canMove = true, bool hitRecovery = true, bool canAttack = true, 
			bool canJump = true, bool ignoresGravity = false, bool ignoresPushes = false, 
			float moveControl = 1f)
		{
			this.canMove = canMove;
			this.hitRecovery = hitRecovery;
			this.canAttack = canAttack;
			this.canJump = canJump;
			this.ignoresGravity = ignoresGravity;
			this.ignoresPushes = ignoresPushes;
			this.moveControl = moveControl;
		}
	}
	public State state = new State();
	public static float gravity = 20f;
	public float speed = 1.0f;
	public float jumpSpeed;
	public float horDir = 1.0f;
	new Rigidbody rigidbody;
	public CharacterController controller;
	public Animator animator;
	public Vector3 Move;
	public Vector3 prevMove;
	public Vector3 Push;
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
		hp.OnDamage.AddListener((damage, attack) => {
			if(state.hitRecovery) 
			{
				
				animator.SetTrigger("hitRecovery" + Random.Range(0, hitRecoveries));
				Face(attack.transform.position - transform.position);
			}
		});
		hp.OnDeath.AddListener((damage, attack) => {
			state.hitRecovery = false;
			animator.SetTrigger("death" + Random.Range(0, deaths));
			controller.enabled = false;
			enabled = false;
		});
	}
	private void Update()
	{
		animator.SetBool("isGrounded", controller.isGrounded);
		//Vector3 move = controller.isGrounded ? Vector3.zero : prevMove;
		Vector3 move = controller.isGrounded ? Vector3.zero : prevMove;

		if(state.canMove)
		{
			move += Move.normalized * speed * state.moveControl;
			//Vector3 vertSpeed = new Vector3(0f, move.y, 0f);
			move = move.normalized * speed;

			Face(move);
		}
		animator.SetFloat("speed", move.sqrMagnitude);

		if(!state.ignoresGravity) move.y -= gravity * Time.deltaTime;

		if(Jump && state.canJump)
		{
			move.y = jumpSpeed;
			animator.SetTrigger("jump");
		}
		Jump = false;

		if(Push != Vector3.zero && !state.ignoresPushes)
		{
			state.canMove = false;
			state.canAttack = false;
			state.canJump = false;
			state.ignoresGravity = false;
			move = Push;
			Push = Vector3.zero;
			//Face(-move);
		}
		Move = Vector3.zero;
		prevMove = move;
		controller.Move(move * Time.deltaTime);
	}

	public void Attack(string attack = "attack")
	{
		if(state.canAttack)
		{
			animator.SetTrigger(attack);
		}
	}

	private void Face(Vector3 dir)
	{
		float dot = Vector3.Dot(dir, Camerizer.Instance.Right);
		if(dot != 0f && Mathf.Sign(dot) != horDir) Flip();
	}
	private void Flip()
	{
		horDir *= -1;
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.y);
	}
}
