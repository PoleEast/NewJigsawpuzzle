using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelog : MonoBehaviour
{
    [HideInInspector]
    public int Checkpoint;
    [HideInInspector]
    public int mode = 3;
    [HideInInspector]
    public static modelog Instance;
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
            Destroy(gameObject);

    }
}
