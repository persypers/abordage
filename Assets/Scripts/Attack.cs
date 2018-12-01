using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	public float damage;
	HashSet<HP> hits = new HashSet<HP>();

	private void OnColliderEnter(Collider other)
	{
		Debug.Log("Collider hit:");
		Debug.Log(other);
		HP hit = other.GetComponent<HP>();
		if(!hit || hits.Contains(hit)) return;
		hits.Add(hit);
		hit.Damage(damage);
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("Trigger hit:");
		Debug.Log(other);
		HP hit = other.GetComponent<HP>();
		if(!hit || hits.Contains(hit)) return;
		hits.Add(hit);
		hit.Damage(damage);
	}

	private void OnDisable()
	{
		hits.Clear();
	}
}
