using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class touchtoquit : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("quit");
            Application.Quit();
        }

    }
}
