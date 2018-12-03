using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChance : StateMachineBehaviour {
 	
	[System.Serializable]
	public struct Entry
	{
		public string name;
		public float weight;
	}
	public Entry[] chances;
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		float totalWeight = 0f;
		for(int i = 0; i < chances.Length; i++)
		{
			totalWeight += chances[i].weight;
		}
		float r = Random.Range(0f, totalWeight);
		int j = 0;
		for(;j < chances.Length; j++)
		{
			r -= chances[j].weight;
			if(r <= 0) break;
		}
		j = Mathf.Min(j, chances.Length - 1);
		if(chances[j].name != "") GlobalScript.PlaySound(chances[j].name);
    }
}
