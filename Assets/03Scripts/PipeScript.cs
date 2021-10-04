using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    [SerializeField] private PipeGameControlScript pipeGameComtroll;
    public string pipeType;     //pipe의 형태 자세한것은 SetPipe()참조
    [NonSerialized] public bool[] pipeHoll = new bool[4];       //파이프의 구멍 참이면 뚫린곳 거짓이면 막힌곳
    [NonSerialized] public bool connectedWithStart = false;     //시작과 연결되어있는지(시작지점은 항상참)
    private bool temp;

    //pipe hollnumber >>
    //   4
    //  3P1   3P1
    //   2
    //after rotation >>
    //   1
    //  4P2
    //   3
    void Awake()
    {
        SetPipe();
    }

    public void ButtonRotate()
    {
        if (pipeGameComtroll.pipeComplete != true)
        {
            transform.Rotate(0, 0, -90);
            //입구회전(시계방향)
            //     false                 false
            //       4                     4
            //false 3P1 true   =>   false 3P1 false
            //       2                     2
            //     false                 true
            //
            temp = pipeHoll[3];
            for (int i = 3; i > 0; i--)
            {
                pipeHoll[i] = pipeHoll[i - 1];
            }
            pipeHoll[0] = temp;
        }
    }

    public void SetPipe()
    {
        PipeReset();
        switch (pipeType)
        {
            case "Angle":       // 7
                pipeHoll[0] = false;
                pipeHoll[1] = true;
                pipeHoll[2] = true;
                pipeHoll[3] = false;
                break;
            case "Plus":        //+
                pipeHoll[0] = true;
                pipeHoll[1] = true;
                pipeHoll[2] = true;
                pipeHoll[3] = true;
                break;
            case "T":           //T
                pipeHoll[0] = true;
                pipeHoll[1] = true;
                pipeHoll[2] = true;
                pipeHoll[3] = false;
                break;
            case "Line":        //-
                pipeHoll[0] = true;
                pipeHoll[1] = false;
                pipeHoll[2] = true;
                pipeHoll[3] = false;
                break;
            case "Start":       //O-
                connectedWithStart = true;
                pipeHoll[0] = true;
                pipeHoll[1] = false;
                pipeHoll[2] = false;
                pipeHoll[3] = false;
                break;
            case "End":       //O-
                pipeHoll[0] = true;
                pipeHoll[1] = false;
                pipeHoll[2] = false;
                pipeHoll[3] = false;
                break;
            default:
                Debug.Log("!===== NO PIPETYPE =====!");
                break;
        }

        for(int a = 0; a < UnityEngine.Random.Range(0f, 3f) / 1; a++)
        {
            ButtonRotate();
        }
    }

    private void PipeReset()
    {
        transform.rotation = Quaternion.identity;
        connectedWithStart = false;
    }
}