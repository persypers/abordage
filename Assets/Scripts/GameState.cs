using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    public static GameState Instance { get; private set; }

    public enum Organ
    {
        Heart,
        Brain,
        Eyes,
        Lungs,
        Liver
    }

    public HashSet<Organ> body = new HashSet<Organ>();
    public HashSet<Organ> altar = new HashSet<Organ>();

    void Awake() {
        Instance = this;
        body.Add(Organ.Heart);
        body.Add(Organ.Liver);
        body.Add(Organ.Lungs);
        body.Add(Organ.Eyes);
        body.Add(Organ.Brain);
    }
	
}
