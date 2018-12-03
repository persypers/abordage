using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oriented : MonoBehaviour {
	public void OnEnable()
	{
        if (Camerizer.Instance) Camerizer.Instance.sprites.Add(this);
	}

	public void OnDisable()
	{
        if (Camerizer.Instance) Camerizer.Instance.sprites.Remove(this);
	}
}
