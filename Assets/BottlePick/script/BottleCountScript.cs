using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleCountScript : MonoBehaviour
{
    [NonSerialized] public float myscore;

    private void Start()
    {
        myscore = PlayerPrefs.GetFloat("myscore", 0f);
    }

    private void LateUpdate()
    {
        PlayerPrefs.SetFloat("myscore", myscore);
    }
}
