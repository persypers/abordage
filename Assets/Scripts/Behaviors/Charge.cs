using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

public class Charge : Action {
	public SharedGameObject target;
	public float distance;
	Creature self;
	public override void OnStart()
	{
		self = GetComponent<Creature>();
		self.speed *= 1.5f;
	}

	public override TaskStatus OnUpdate()
	{
		Vector3 dir = target.Value.transform.position - transform.position;
		dir = new Vector3(dir.x, 0f, dir.z);
		if(dir.magnitude <= distance)
		{
			return TaskStatus.Success;
		}
		self.Move = dir;
		return TaskStatus.Running;
	}

	public override void OnEnd()
	{
		self.speed /= 1.5f;
	}
}
