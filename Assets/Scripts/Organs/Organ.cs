using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organ : MonoBehaviour {

    public string varName;
    public GameObject icon;
    public GameObject absentEffect;

    public Creature player;

    public bool _IsActive;
    public virtual bool IsActive
    {
        get { return _IsActive; }
        set
        {
            if (_IsActive != value)
            {
                _IsActive = value;
                if (icon) icon.SetActive(_IsActive);
                if (absentEffect) absentEffect.SetActive(!_IsActive);
                PlayMakerGlobals.Instance.Variables.FindFsmBool(varName).Value = value;
                OnUpdate();
            }
        }
    }

    protected virtual void OnUpdate() { }

    protected virtual void Awake()
    {
        var p = GetComponentInParent<Player>();
        player = p.GetComponent<Creature>();
    }

    protected void OnEnable()
    {
        IsActive = PlayMakerGlobals.Instance.Variables.FindFsmBool(varName).Value;
        if (icon) icon.SetActive(IsActive);
        if (absentEffect) absentEffect.SetActive(!IsActive);
        OnUpdate();
    }

}
