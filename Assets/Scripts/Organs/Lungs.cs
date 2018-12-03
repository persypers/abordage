using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lungs : Organ {

    public float speedWith= 8f;
    public float speedWithout = 5f;

    protected override void OnUpdate()
    {
        base.OnUpdate();
        player.speed = IsActive ? speedWith : speedWithout;
    }
}
