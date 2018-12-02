using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	public float damage;
	HashSet<HP> hits = new HashSet<HP>();
	private void OnTriggerEnter(Collider other)
	{
		HP hit = other.GetComponent<HP>();
		if(!hit || hits.Contains(hit)) return;
		hits.Add(hit);
		hit.Damage(damage, this);
	}

	private void OnDisable()
	{
		hits.Clear();
	}
}
