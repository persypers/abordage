using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oriented : MonoBehaviour {
	public void OnEnable()
	{
		Camerizer.Instance.sprites.Add(this);
	}

	public void OnDisable()
	{
		Camerizer.Instance.sprites.Remove(this);
	}
}
