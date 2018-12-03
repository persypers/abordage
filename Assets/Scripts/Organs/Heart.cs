using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Organ {

    public float hpWithHeart = 100f;
    public float hpWithoutHeart = 35f;

    protected override void OnUpdate()
    {
        base.OnUpdate();
        HP hp = player.GetComponent<HP>();
        float percentile = hp.value / hp.maxValue;
        hp.maxValue = IsActive ? hpWithHeart : hpWithoutHeart;
        hp.value = Mathf.Max(percentile * hp.maxValue, hp.value);
    }
}
