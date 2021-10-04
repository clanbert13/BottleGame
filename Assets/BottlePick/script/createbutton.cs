using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createbutton : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject Canvas;
    public int _x;
    public int _y;
    int[] x = {580, 580,120,200,460,980,1100,1100,1380,1780,1580,980};
    int[] y = {430, 800,800,430,320,320,180,950,480,320,800,690};
    bool[] check = new bool[12] { false, false, false, false, false, false, false, false, false, false, false, false};
    // Start is called before the first frame update
    void Start()
    {
        //Transform Parent = GameObject.Find("BlockParent").GetComponent<Transform>();
        InvokeRepeating("initbutton", 2, 2);
    }
    public void initbutton()
    {
        int what = UnityEngine.Random.Range(0, 2);
        int xy = UnityEngine.Random.Range(0, 11);
        //if (!check[xy])
        //{
        //    GameObject child = Instantiate(button1, new Vector3(x[xy], y[xy], 0), Quaternion.identity) as GameObject;
        //    child.transform.SetParent(Canvas.transform);
        //    check[xy] = true;
        //}
        //else {
        //    initbutton();
        //}
        if (what == 0)
        {
            GameObject child = Instantiate(button1, new Vector3(x[xy], y[xy], 0), Quaternion.identity) as GameObject;
            child.transform.SetParent(Canvas.transform);
        }
        if (what == 1)
        {
            GameObject child = Instantiate(button2, new Vector3(x[xy], y[xy], 0), Quaternion.identity) as GameObject;
            child.transform.SetParent(Canvas.transform);
        }
        if (what == 2)
        {
            GameObject child = Instantiate(button3, new Vector3(x[xy], y[xy], 0), Quaternion.identity) as GameObject;
            child.transform.SetParent(Canvas.transform);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
