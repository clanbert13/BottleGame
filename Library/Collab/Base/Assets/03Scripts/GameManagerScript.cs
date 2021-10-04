using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManagerScript : MonoBehaviour
{
    [Header("Bottle")]
    [SerializeField] private Text bottleText;
    [SerializeField] private Text noBottleText;
    [Tooltip("drag buttons to here")]
    [SerializeField] private BottleCountScript bottleCountScript ;//script in button(pikcing bottles)

    [Header("Machine Level")]
    public float machineLevel;      //미사용

    [Header("DrinksCount")]
    [SerializeField] private Text[] drinkText;      //음료 개수 출력

    [Header("MiniGame")]
    [SerializeField] private GameObject pipeGame;

    public float[] drinkAmount;//[X]번 음료 개수
    private bool result;//pipe게임 결과 받아올때 사용
    private float waitTime; //Timer함수사용시 waitTime을 먼저 설정하여 선택한시간만큼 기다리게함
    [NonSerialized] public int type;        //type 0:콜라, 1:사이다, 2:에너지드링크, 3:이온음료, 4:커피

    public float bottle = 0.0f;
    void Start()
    {
        noBottleText.text = null;
        drinkAmount = new float[drinkText.Length];
    }
    
    void Update()
    {
        bottle = bottleCountScript.myscore;
        bottleText.text = "병 : " + bottle.ToString();//현재 병의 개수 출력
        GetDrink(type);
        for (int i = 0; i < drinkText.Length; i++) drinkText[i].text = "수량 : " + drinkAmount[i].ToString();
        //음료 종류에 따른 수 출력
    }

    public void drinkButton(int input)
    {
        if (bottle == 0)
        {
            noBottleText.text = "==병이 부족합니다==";

            StartCoroutine("waitRemoveText");
        }
        else {
            type = input;
            pipeGame.SetActive(true); 
        }
    }
    public void GetDrink(int drinkType)
    {
        if (result == true)
        {
            /*
            switch (type)//음료수종류에따른 시간선택
            {
                case 0:
                case 1:
                    //콜라 사이다의 경우
                    break;
                case 2:
                case 3:
                    //에너지드링크 이온음료의 경우
                    break;
                    case 4:
                    //커피의 경우
                    break;
            }
            StartCoroutine("Timer");
            */
            drinkAmount[drinkType]++;       //해당종류의 음료 개수 증가
            result = false;
        }
    }

    private IEnumerator Timer()     //waitTime만큼 시간 대기
    {
        yield return new WaitForSeconds(waitTime);
        //이곳에 내용을 추가하면 waitTime만큼 대기하다 실행
    }  
    private IEnumerator waitRemoveText()//0.5초후 텍스트 null
    {
        yield return new WaitForSeconds(0.5f);
        noBottleText.text = null;
    }

    public void GameResult(bool r)  //pipeGameControl에서 게임 결과 받아오는 함수
    {
        result = r;
    }
}
