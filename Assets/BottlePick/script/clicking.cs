using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;


public class clicking : MonoBehaviour
{
    public GameObject but;
    //효과음
    public GameObject sound;
    //클릭시 점수 얻고 해당 스폰포인트 활성화 후 효과음 발생
    public void clickbutton0()
    {
        //쓰레기 봉투
        GameObject.Find("ScoreObj").GetComponent<BottleCountScript>().myscore += 10;
        GameObject.Find("GameManager").GetComponent<spawnitem>().spawns[0].SetActive(true);
        Instantiate(sound, but.transform.position, but.transform.rotation);
        Destroy(but);
    }
    public void clickbutton1()
    {
        //쓰레기 봉투
        GameObject.Find("ScoreObj").GetComponent<BottleCountScript>().myscore += 10;
        GameObject.Find("GameManager").GetComponent<spawnitem>().spawns[1].SetActive(true);
        Instantiate(sound, but.transform.position, but.transform.rotation);
        Destroy(but);
    }
    public void clickbutton2()
    {
        //쓰레기 병
        GameObject.Find("ScoreObj").GetComponent<BottleCountScript>().myscore += 5;
        GameObject.Find("GameManager").GetComponent<spawnitem>().spawns[2].SetActive(true);
        Instantiate(sound, but.transform.position, but.transform.rotation);
        Destroy(but);
    }
    public void clickbutton3()
    {
        //쓰레기 병
        GameObject.Find("ScoreObj").GetComponent<BottleCountScript>().myscore += 5;
        GameObject.Find("GameManager").GetComponent<spawnitem>().spawns[3].SetActive(true);
        Instantiate(sound, but.transform.position, but.transform.rotation);
        Destroy(but);
    }
    public void clickbutton4()
    {
        //쓰레기 봉투
        GameObject.Find("ScoreObj").GetComponent<BottleCountScript>().myscore += 10;
        GameObject.Find("GameManager").GetComponent<spawnitem>().spawns[4].SetActive(true);
        Instantiate(sound, but.transform.position, but.transform.rotation);
        Destroy(but);
    }
    public void clickbutton5()
    {
        //쓰레기 병
        GameObject.Find("ScoreObj").GetComponent<BottleCountScript>().myscore += 5;
        GameObject.Find("GameManager").GetComponent<spawnitem>().spawns[5].SetActive(true);
        Instantiate(sound, but.transform.position, but.transform.rotation);
        Destroy(but);
    }
    public void clickbutton6()
    {
        //쓰레기 병
        GameObject.Find("ScoreObj").GetComponent<BottleCountScript>().myscore += 5;
        GameObject.Find("GameManager").GetComponent<spawnitem>().spawns[6].SetActive(true);
        Instantiate(sound, but.transform.position, but.transform.rotation);
        Destroy(but);
    }
    public void clickbutton7()
    {
        //쓰레기 봉투
        GameObject.Find("ScoreObj").GetComponent<BottleCountScript>().myscore += 10;
        GameObject.Find("GameManager").GetComponent<spawnitem>().spawns[7].SetActive(true);
        Instantiate(sound, but.transform.position, but.transform.rotation);
        Destroy(but);
    }
    public void clickbutton8()
    {
        //쓰레기 병
        GameObject.Find("ScoreObj").GetComponent<BottleCountScript>().myscore += 5;
        GameObject.Find("GameManager").GetComponent<spawnitem>().spawns[8].SetActive(true);
        Instantiate(sound, but.transform.position, but.transform.rotation);
        Destroy(but);
    }
    public void clickbutton9()
    {
        //쓰레기 병
        GameObject.Find("ScoreObj").GetComponent<BottleCountScript>().myscore += 5;
        GameObject.Find("GameManager").GetComponent<spawnitem>().spawns[9].SetActive(true);
        Instantiate(sound, but.transform.position, but.transform.rotation);
        Destroy(but);
    }
    public void clickbutton10()
    {
        //쓰레기 통
        GameObject.Find("ScoreObj").GetComponent<BottleCountScript>().myscore += 15;
        GameObject.Find("GameManager").GetComponent<spawnitem>().spawns[10].SetActive(true);
        Instantiate(sound, but.transform.position, but.transform.rotation);
        Destroy(but);
    }
    public void clickbutton11()
    {
        //쓰레기 통
        GameObject.Find("ScoreObj").GetComponent<BottleCountScript>().myscore += 15;
        GameObject.Find("GameManager").GetComponent<spawnitem>().spawns[11].SetActive(true);
        Instantiate(sound, but.transform.position, but.transform.rotation);
        Destroy(but);
    }



    //public void Des()
    //{
    //    UnityEngine.Debug.Log("삭제");
    //    Destroy(but);
    //}
    // Start is called before the bfirst frame update
    void Start()
    {
        //UnityEngine.Debug.Log("시작");
    }
    public void getText()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
