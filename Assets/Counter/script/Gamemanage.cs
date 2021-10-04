using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanage : MonoBehaviour
{
    //계산완료 효과음
    public GameObject sound;
    //첫번째 손님의 음료종류,돈
    public int drinktype;
    public int moneyamount;
    //생성된 소비자를 자녀오브젝트로 넣기위해 사용
    public GameObject parent;
    //게임전체의 돈과 음료수의 갯수를 수정하기위해 사용
    public GameObject Main;
    //counter오브젝트와 손님과의 거리를 확인하기위해 사용
    public GameObject counter;
    //6명의 손님중에서 랜덤하게 오기때문에 배열로사용
    public GameObject[] consumer;
    //카운터에 서있는 손님을 list배열로 구현했다
    public List<GameObject> Objects = new List<GameObject>();
    //counterbutton오브젝트와 상호작용하기 위해 사용
    public GameObject Counterbutton;
    //소비자가 있는지 없는지 확인
    public bool consumerhere = false;
    //음료수가 부족할경우 경고메세지 출력으로 사용
    public GameObject concern;

    //소비자가 몇명있는지 확인
    public int consumercount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //list배열의 첫번째에 counter오브젝트를 넣어준다
        Objects.Add(counter);
        //5초마다 손님이 추가로 온다
        InvokeRepeating("initconsumer", 5, 5);
        //InvokeRepeating("deq", 20, 20);
    }

    //손님이 줄어드는 함수
    public void deq()
    {
        //첫번째 손님의 음료와 돈 받기     
        drinktype = Objects[1].GetComponent<consumermove>().drink;
        moneyamount = Objects[1].GetComponent<consumermove>().money;
        //해당 음료수종류의 개수가 1개이상일때 실행
        if (Main.GetComponent<GameManagerScript>().drinkAmount[drinktype] != 0)
        {
            //계산완료 효과음 생성
            Instantiate(sound, this.transform.position, this.transform.rotation);
            //첫번째 손님의 음료와 돈 받기     
            drinktype = Objects[1].GetComponent<consumermove>().drink;
            moneyamount = Objects[1].GetComponent<consumermove>().money;
            //소지한 돈에서 얻은 돈만큼 추가하고 음료수를 한개뺀다
            Main.GetComponent<GameManagerScript>().money += moneyamount;
            Main.GetComponent<GameManagerScript>().drinkAmount[drinktype] -= 1;
            //첫번째 손님의 오브젝트를 없에고 계산서UI를끈다
            Objects[1].GetComponent<consumermove>().destroy();
            Counterbutton.GetComponent<Counter>().desimage();
            Counterbutton.GetComponent<Counter>().bill.SetActive(false);

            //리스트에서 첫번째 손님을 뺀다
            Objects.RemoveAt(1);
        }
        else
        {
            concern.SetActive(true);
        }
    }

    //손님 생성함수
    public void initconsumer()
    {
        //최대손님 명수인 4명을 넘지 않으면 실행(카운터포함 X이므로 5보다 작을때까지)
        if (Objects.Count < 5)
        {
            //소비자의 종류가 6명이므로 랜덤함수로 어떤 손님이 올지 정한다
            int kind_of_consumer = UnityEngine.Random.Range(0, 6);
            //kind_of_consumer종류의 손님이 생성되고 tempobject로 저장된다
            GameObject tempobject = Instantiate(consumer[kind_of_consumer], consumer[kind_of_consumer].transform.position, consumer[kind_of_consumer].transform.rotation) as GameObject;
            tempobject.transform.parent = parent.transform;
            //tempobject를 리스트에 넣어준다
            Objects.Add(tempobject);
        }
    }
    //각 오브젝트가 자신의 앞에있는 오브젝트를 바라보게 해주는 함수
    public void lookat()
    {
        for (int i = 1; i < Objects.Count; i++)
        {
            Objects[i].GetComponent<consumermove>().tempobj = Objects[i - 1];
        }
    }
    //제일 첫번째있는 손님을 카운터오브젝트에 넘겨준다
    public void counter_consumer()
    {
        Counterbutton.GetComponent<Counter>().consumer = Objects[1];
    }
    // Update is called once per frame
    void Update()
    {
        //함수 실행
        lookat();
        consumercount = Objects.Count;
        //손님이 있는지 없는지를 큐의 크기를 사용해 확인
        if (consumercount == 1)
        {
            consumerhere = false;
        }
        else if (consumercount > 1)
        {
            consumerhere = true;
        }
        //손님이있다면 카운터오브젝트에 1번째 오브젝트를 넘겨준다
        if (consumerhere)
        {
            counter_consumer();
        }
    }
}
