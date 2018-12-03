using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HP : MonoBehaviour
{
	[System.Serializable]
	public class OnDamageEvent : UnityEvent<float, Attack> {}
	public OnDamageEvent OnDamage = new OnDamageEvent(); 
	public OnDamageEvent OnDeath = new OnDamageEvent(); 
	public float maxValue;
    public float value;
	public bool isInvincible;
	
	private void Start()
	{
		value = maxValue;
	}
	public void Damage(float amount, Attack attack)
	{
		if(isInvincible) return;
		value -= amount;
		if(value <= 0f)
		{
			OnDeath.Invoke(Mathf.Abs(value), attack);
		}
		value = Mathf.Clamp(value, 0f, maxValue);
		OnDamage.Invoke(amount, attack);
	}
}
