using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplash : MonoBehaviour {
	public Attack host;

	public void ReturnToHost()
	{
		transform.parent = host.transform;
		gameObject.SetActive(false);
		host.splashQueue.Enqueue(this);
	}
}
