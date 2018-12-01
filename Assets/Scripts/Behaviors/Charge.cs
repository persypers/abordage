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
		float curDistance = (target.Value.transform.position - transform.position).magnitude;
		if(curDistance <= distance)
		{
			return TaskStatus.Success;
		}
		self.Move = target.Value.transform.position - transform.position;
		return TaskStatus.Running;
	}

	public override void OnEnd()
	{
		self.speed /= 1.5f;
	}
}
