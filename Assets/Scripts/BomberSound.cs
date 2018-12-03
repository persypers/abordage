using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberSound : MonoBehaviour {
	public AudioSource fuse;
	public AudioSource boom;
	public void BomberFuseSound()
	{
		fuse.pitch = Random.Range(0.9f, 1.1f);
		fuse.Play();
	}

	public void BomberBoomSound()
	{
		
		fuse.Stop();
		boom.pitch = Random.Range(0.9f, 1.1f);
		boom.Play();
	}
}
