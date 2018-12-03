using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : Organ {

    public float swayForce = 10f;
    public float sway;
    public Animation anim;

    float prevSway = 0f;

    protected override void OnUpdate()
    {
        base.OnUpdate();
        if (!IsActive)
        {
            prevSway = 0f;
            anim.Play();
        }
        else anim.Stop();
    }

    private void Update()
    {
        if(!IsActive)
        {
            float s = sway * swayForce;
            float rotation = s - prevSway;
            //rotation *= player.animator.GetFloat("speed") / (player.speed * player.speed);
            Vector3 eul = transform.rotation.eulerAngles;
            player.transform.rotation = Quaternion.Euler(eul.x, eul.y + rotation, eul.z);
            prevSway = s;

        }
    }
}
