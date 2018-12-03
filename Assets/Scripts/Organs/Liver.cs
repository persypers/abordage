using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liver : Organ {

    public float regenPerSec = 2f;
    public HP hp;

    protected override void Awake()
    {
        base.Awake();
        HP hp = player.GetComponent<HP>();
    }

    private void Update()
    {
        if(IsActive)
        {
            hp.value = Mathf.Min(hp.maxValue, hp.value + regenPerSec * Time.deltaTime);
        }
    }
}