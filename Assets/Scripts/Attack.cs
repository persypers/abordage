using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	public float damage;
	HashSet<HP> hits = new HashSet<HP>();	
	public BloodSplash[] splashes;

	public Queue<BloodSplash> splashQueue = new Queue<BloodSplash>();
	void Awake()
	{
		foreach(var s in splashes)
		{
			s.gameObject.SetActive(false);
			splashQueue.Enqueue(s);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		HP hit = other.GetComponent<HP>();
		if(!hit || hits.Contains(hit)) return;
		hits.Add(hit);
		hit.Damage(damage, this);
		if(splashQueue.Count > 0)
		{
			BloodSplash splash = splashQueue.Dequeue();
			Vector3 pos = Vector3.Lerp(transform.position, other.transform.position, 0.5f);
			splash.transform.position = pos;
			splash.gameObject.SetActive(true);
			splash.host = this;
			splash.transform.parent = null;
		}

	}

	private void OnDisable()
	{
		hits.Clear();
	}
}
