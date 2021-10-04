using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounddelete : MonoBehaviour
{
    public GameObject own;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("des", time);
    }
    public void des()
    {
        Destroy(own);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
