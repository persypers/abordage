using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodifier : MonoBehaviour {
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
		BloodSplash splash = splashQueue.Dequeue();
		if(splash)
		{
			Vector3 pos = collision.contacts[0].point;
			splash.transform.position = pos;
			splash.gameObject.SetActive(true);
			//splash.host = this;
			splash.transform.parent = null;
		}
	}
}
