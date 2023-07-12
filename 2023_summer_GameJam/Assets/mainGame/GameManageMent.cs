using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManageMent : MonoBehaviour
{
    public Transform PlayerPos;
    public GameObject[] Human = new GameObject[7];

    private static GameManageMent instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
