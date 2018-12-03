using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

public class Charge : Action {
	public SharedGameObject target;
	public float distance;
	public float speedBoost = 1f;
	Creature self;
	public override void OnStart()
	{
		self = GetComponent<Creature>();
		self.speed *= speedBoost;
	}

	public override TaskStatus OnUpdate()
	{
		Vector3 dir = target.Value.transform.position - transform.position;
		dir = new Vector3(dir.x, 0f, dir.z);
		if(dir.magnitude <= distance)
		{
			return TaskStatus.Success;
		}
		if(self.state.canMove) self.Move = dir;
		return TaskStatus.Running;
	}

	public override void OnEnd()
	{
        self.speed /= speedBoost;
	}
}
