using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour {
	public void OnTriggerEnter(Collider other)
	{
		Creature hit = other.GetComponent<Creature>();
		if(hit) GameObject.Destroy(hit.gameObject);
	}
}
