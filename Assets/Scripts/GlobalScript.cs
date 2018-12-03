using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour {
    public static GlobalScript Instance { get; private set; }

    private void Awake()
    {
        if (Instance)
        {
            GameObject.Destroy(gameObject);
            return;
        }
        GameObject.DontDestroyOnLoad(gameObject);
        Instance = this;
    }
}
