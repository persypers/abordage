using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerizer : MonoBehaviour {
	public static Camerizer _instance;
	public static Camerizer Instance
	{
		get
		{
			if(!_instance) _instance = GameObject.FindObjectOfType<Camerizer>();
			return _instance;
		}
	}

	public Transform right;
	public Transform depth;
	public Transform up;
//	public Vector3 Right{get; private set;}
//	public Vector3 Depth{get; private set;}
//	public Vector3 Up{get; private set;}
	public Vector3 Right{get {return transform.right;}}
	public Vector3 Depth{get {return transform.forward;}}
	public Vector3 Up{get {return transform.up;}}
	public void OnDestroy()
	{
		if(_instance == this) _instance = null;
	}

	public HashSet<Oriented> sprites = new HashSet<Oriented>();

	public void Update()
	{
		foreach(var sprite in sprites)
		{
			sprite.transform.forward = Depth;
		}
	}
/* 	public void FixedUpdate()
	{
		Right = (right.position - transform.position).normalized;
		Depth = (depth.position - transform.position).normalized;
		Up = (up.position - transform.position).normalized;
	}
*/}
