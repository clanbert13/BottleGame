using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoretext : MonoBehaviour
{
    public int myscore = 0;

    public void getText()
    {
        myscore.ToString();
    }

    void Update()
    {
        getText();
    }
}
