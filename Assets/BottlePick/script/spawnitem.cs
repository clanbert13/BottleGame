using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnitem : MonoBehaviour
{//스폰 포인트를 생성해 해상 스폰포인트가 활성화 되어있으면 해당 위치에 아무것도없는것.
    //만약 비활성와 되어있다면 해당 스폰포인트에 쓰레기가 있는것으로  판단해 중복을 업앴다
    public GameObject Canvas;
    public GameObject[] spawns;
    public GameObject[] buttons;
    public ChangeScreenScript changeScreenScript;
    public bool active;

    void Start()
    {
        InvokeRepeating("initbutton", 2, 2);
    }
    public void initbutton()
    {
        int xy = UnityEngine.Random.Range(0, 12);
        if (spawns[xy].activeSelf)
        {
            GameObject child = Instantiate(buttons[xy], spawns[xy].transform.position, Quaternion.identity) as GameObject;
            child.transform.SetParent(Canvas.transform);
            spawns[xy].SetActive(false);
        }
        else
        { //모든 스폰포인트가 다 비활성화 되어있다면 함수 실행을 하지 않는다
           if(!(!spawns[0].activeSelf && !spawns[1].activeSelf && !spawns[2].activeSelf && !spawns[3].activeSelf && !spawns[4].activeSelf && !spawns[5].activeSelf &&
                 !spawns[6].activeSelf && !spawns[7].activeSelf && !spawns[8].activeSelf && !spawns[9].activeSelf && !spawns[10].activeSelf && !spawns[11].activeSelf))
            {
                initbutton();
            }
        }
    }
}
