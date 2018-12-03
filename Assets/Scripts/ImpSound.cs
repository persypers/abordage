using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpSound : MonoBehaviour {
	public AudioSource[] attacks;
	public AudioSource[] annoys;
	public AudioSource[] hits;

	protected void Play(AudioSource source)
	{
		if(!source.isPlaying) {
			source.Play();
		}
	}

	public void ImpAttackSound()
	{
		var audio = attacks[Random.Range(0, attacks.Length)];
		audio.pitch = Random.Range(0.9f, 1.1f);
		audio.Play();
	}

	public void ImpAnnoySound()
	{
		var audio = annoys[Random.Range(0, annoys.Length)];
		audio.pitch = Random.Range(0.9f, 1.1f);
		audio.Play();
	}

	public void ImpHitSound()
	{
		var audio = hits[Random.Range(0, hits.Length)];
		audio.pitch = Random.Range(0.9f, 1.1f);
		audio.Play();
	}

}
