using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSound : MonoBehaviour {
	public AudioSource appear;
	public AudioSource[] attacks;
	public AudioSource[] annoys;
	public AudioSource[] hits;

	protected void Play(AudioSource source)
	{
		
		if(!source.isPlaying) {
			source.Play();
		}
	}

	public void BossAppearSound()
	{
		appear.Play();
	}

	public void BossAttackSound()
	{
				foreach(var a in annoys)
		{
			if(a.isPlaying) return;
		}
		var audio = attacks[Random.Range(0, attacks.Length)];
		audio.pitch = Random.Range(0.9f, 1.1f);
		audio.Play();
	}

	public void BossAnnoySound()
	{
		foreach(var a in annoys)
		{
			if(a.isPlaying) return;
		}
		var audio = annoys[Random.Range(0, annoys.Length)];
		//audio.pitch = Random.Range(0.9f, 1.1f);
		audio.Play();
	}

	public void BossHitSound()
	{
		foreach(var a in annoys)
		{
			if(a.isPlaying) return;
		}
		var audio = hits[Random.Range(0, hits.Length)];
		//audio.pitch = Random.Range(0.9f, 1.1f);
		audio.Play();
	}

}
