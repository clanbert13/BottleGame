using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consumermove : MonoBehaviour
{
    //자신의 앞 오브젝트
    public GameObject tempobj;
    //자신의 앞과 자신과의 거리
    public float distance;
    //이동하는 속도
    public float movepower;
    //자신(삭제할때 이용)
    public GameObject con;
    //음료수의 종류   0 = 콜라    1 = 사이다     2 = 에너지 드링크     3 = 이온 음료     4 = 커피
    public int drink;
    //음료수의 종류에따라 돈배열로 적용
    public int[] drinkmoney = { 1000, 1000, 1500, 1500, 2000 };
    //소비자가 원하는 음료의 돈 
    public int money;
    //애니메이션 사용
    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
    }
    public void watching(GameObject gameobject)
    {   //자신의 앞에있는 오브젝트를 받아서 tempobj에 넣어준다
        tempobj = gameobject;   
    }

    // Update is called once per frame
    void Update()
    {
        //돈 정하는 함수 호출
        setmoney();
        //자신의 앞에있는 오브젝트와 자신사이의 거리를 계산해 distance변수에 넣는다
        distance = Vector3.Distance(this.transform.position, tempobj.transform.position);
        if (distance > 4)
        {   //거리가 3 이상이라면 이동시킨다
            this.transform.Translate(new Vector3(movepower, 0, 0));
            animator.SetBool("Walk", false);
        }
        else {
            animator.SetBool("Walk", true);
        }
    }
    public void destroy()
    {   //오브젝트 파괴
        Destroy(con);
    }
    //음료수 종류의 따라 돈 정하기
    public void setmoney()
    {   //i번째 음료면 i번째 음료의 가격을 money변수에 넣는다
        for(int i = 0; i < 5; i++)
        {
            if(i == drink)
            {
                money = drinkmoney[i];
                break;
            }
        }
    }
}
