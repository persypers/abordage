﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

public class Seek : Action {
	public SharedGameObject target;
	public float distance;
	public float remainingDistance;
	public static float interval = 1f;
	public NavMeshAgent agent;
	Creature self;
	float t;
	public override void OnStart()
	{
		if(!agent) agent = GetComponent<NavMeshAgent>();
		self = GetComponent<Creature>();
		agent = GetComponent<NavMeshAgent>();
		agent.updatePosition = false;
		agent.updateRotation = false;
		//agent.enabled = true;
		//agent.nextPosition = transform.position;
		//agent.destination = target.Value.transform.position;
		t = interval;
	}

	public override TaskStatus OnUpdate()
	{
		float curDistance = (target.Value.transform.position - transform.position).magnitude;
		t += Time.deltaTime;
		if(self.state.canMove)
		{
			if(!agent.enabled)
			{
				agent.enabled = true;
				agent.nextPosition = transform.position;
				agent.destination = target.Value.transform.position;
				t = 0;
			}
		} else 
		{
			agent.enabled = false;
		}
		if(agent.pathPending) {
			return TaskStatus.Running;
		}
		else if(curDistance <= distance)
		{
			return TaskStatus.Success;
		} else if(t > interval)
		{
			agent.destination = target.Value.transform.position;
			t = 0;
		}
		self.Move = new Vector3(agent.desiredVelocity.x, 0f, agent.desiredVelocity.z);
		agent.velocity = self.controller.velocity;

		return TaskStatus.Running;
	}

	public override void OnEnd()
	{
		agent.enabled = false;
	}
}
