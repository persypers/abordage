using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour {
	public float force = 6;
	public float verticalForce = 4f;
	//HashSet<HP> hits = new HashSet<HP>();
	private void OnTriggerEnter(Collider other)
	{
		Creature hit = other.GetComponent<Creature>();
		if(hit)
		{
			Vector3 dir = (hit.transform.position - transform.position);
			dir = new Vector3(dir.x, 0f, dir.z);
			dir = dir.normalized * force + new Vector3(0f, verticalForce, 0f);
			hit.Push += dir;
		}

	}

	private void OnDisable()
	{
		//hits.Clear();
	}
}