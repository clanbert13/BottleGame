using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    //계산서 UI
    public GameObject bill;
    //gamemanager안의 함수를 이용하기 위해 사용
    public GameObject Gamemanager;
    //consumer의 함수를 이용하기 위해 사용
    public GameObject consumer;
    //계산서에서 소비자가 원하는 음료수를 이미지로 보여주려고 사용

    public GameObject[] drinks;
    //주문하는 음료수
    public Text Order;
    //주문하는 음료수의 금액
    public Text Money;

    //카운터 클릭시 실행되는 함수
    public void onclick()
    {   //소비자가 존재하고 계산서가 떠있지 않다면 실행
        if (Gamemanager.GetComponent<Gamemanage>().consumerhere && !bill.activeSelf)
        {
            //계산서 UI를 키고 그안에 내용을 적어준다
            bill.SetActive(true);
            Gamemanager.GetComponent<Gamemanage>().concern.SetActive(false);
            Order.text = "음료수 : ";
            drinks[consumer.GetComponent<consumermove>().drink].SetActive(true);
            Money.text = "가격 : " + consumer.GetComponent<consumermove>().money;
            UnityEngine.Debug.Log(consumer.GetComponent<consumermove>().drink);
        }
    }

    //계산서의 오른쪽 위에 있는 X버튼을 누를 시 실행되는함수
    public void NoButton()
    { 
        //계산서 UI를 꺼준다
        bill.SetActive(false);
    }

    public void YesButton()
    {   //손님에게 음료수를 파는 버튼을 누를시 실행되는 함수
        //drinks[consumer.GetComponent<consumermove>().drink].SetActive(false);
        //줄서있는 손님중 가장 앞의 손님을 없애주는 함수
        Gamemanager.GetComponent<Gamemanage>().deq();
        //계산서 UI끄기
        //bill.SetActive(false);
    }
    public void desimage()
    {
        drinks[consumer.GetComponent<consumermove>().drink].SetActive(false);
    }
}
