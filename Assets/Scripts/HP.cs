using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HP : MonoBehaviour
{
	[System.Serializable]
	public class OnDamageEvent : UnityEvent<float> {}
	public OnDamageEvent OnDamage = new OnDamageEvent(); 
	public OnDamageEvent OnDeath = new OnDamageEvent(); 
	public float maxValue;
	public float value {get; private set;}
	public bool isInvincible;
	
	private void Start()
	{
		value = maxValue;
	}
	public void Damage(float amount)
	{
		if(isInvincible) return;
		value -= amount;
		if(value <= 0f)
		{
			OnDeath.Invoke(Mathf.Abs(value));
		}
		value = Mathf.Clamp(value, 0f, maxValue);
		OnDamage.Invoke(amount);
	}
}
