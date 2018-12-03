using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacrificeController : MonoBehaviour {

    public bool CanSacrifice(GameState.Organ organ)
    {
        return GameState.Instance.body.Contains(organ) && !GameState.Instance.altar.Contains(organ);
    }

    public void Sacrifice(GameState.Organ organ)
    {
        if(CanSacrifice(organ))
        {

        }
    }

    public void Summon()
    {

    }
}
