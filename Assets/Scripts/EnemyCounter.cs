using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour {
	public static EnemyCounter Instance{get; private set;}
	HashSet<Creature> creatures = new HashSet<Creature>();
	
	int spawnedEnemies = 0;
	int killedEnemies = 0;
	
	void Awake()
	{
		Instance = this;
		var arr = GameObject.FindObjectsOfType<Creature>();
		foreach(Creature c in arr)
		{
			Register(c);
		}
	}
	void OnDestroy()
	{
		if(Instance == this) Instance = null;
	}

	protected void Register(Creature c)
	{
		if(!creatures.Contains(c))
		{
			creatures.Add(c);
			if(!c.GetComponent<Player>()) spawnedEnemies++;
			c.GetComponent<HP>().OnDeath.AddListener((amount, attack) => {OnCreatureDied(c);});
		}
	}

	public static void RegisterNahui(Creature c)
	{
		if(Instance) Instance.Register(c);
	}

	public void OnCreatureDied(Creature c)
	{
		if(c.GetComponent<Player>()) return;
		killedEnemies++;
		if(killedEnemies >= spawnedEnemies) Win();
	}

	public void Win()
	{

	}
}
