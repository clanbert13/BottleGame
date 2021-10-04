using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGameControlScript : MonoBehaviour
{
    [SerializeField] private GameManagerScript gameManager;
    [SerializeField] private GameObject[] pipes;
    [SerializeField] private PipeScript[] pipesScript;
    [SerializeField] private GameObject completeImage;
    [SerializeField] private GameObject pipeGame;

    private int start = -1;        //start pipe's pivot           -1 : not founded
    private int end = -1;          // end 
    private bool notConnected;

    private Vector2 bar1;
    private Vector2 bar2;
    private bool once = true;

    public bool pipeComplete;

    void Awake()
    {
        gameManager.GameResult(false);
        pipeGame.SetActive(false);
        completeImage.SetActive(false);
        pipeComplete = false;
    }

    private void Start()
    {

        for (int a = 0; a < pipes.Length; a++)
        {
            if (pipesScript[a].pipeType == "Start")
            {
                Debug.Log("found start");
                start = a;
            }
            if (pipesScript[a].pipeType == "End") 
            {
                Debug.Log("found end");
                end = a;
            }
        }
    }

    void Update()
    {
        CheckConnection();

        if (pipesScript[end].connectedWithStart == true && once) {
            once = false;
            pipeComplete = true;
            completeImage.SetActive(true);
            Debug.Log("PipeComplete");
            StartCoroutine("CompleteTimer");
            gameManager.GameResult(true);     //true == win
        }
    }

    private IEnumerator CompleteTimer()
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < pipesScript.Length; i++) pipesScript[i].SetPipe();
        pipeComplete = false;
        once = true;
        completeImage.SetActive(false);
        pipeGame.SetActive(false);
    }

    public void CheckConnection()
    {
        for (int pivot = 1; pivot < pipesScript.Length; pivot++)
        {
            //pipesScript[start].connectedWithStart = true;
            if (pipesScript[pivot - 1].connectedWithStart == true)
            {
                notConnected = false;
                bar2 = pipes[pivot].transform.position;
                bar1 = pipes[pivot - 1].transform.position;
                if (bar1.x < bar2.x)
                {
                    if (pipesScript[pivot - 1].pipeHoll[0] && pipesScript[pivot].pipeHoll[2])
                    {
                        pipesScript[pivot].connectedWithStart = true;
                        notConnected = true;
                    }
                }
                else if (bar1.x > bar2.x)
                {
                    if (pipesScript[pivot - 1].pipeHoll[2] && pipesScript[pivot].pipeHoll[0])
                    {
                        pipesScript[pivot].connectedWithStart = true;
                        notConnected = true;
                    }
                }
                else if (bar1.y < bar2.y) 
                {
                    if (pipesScript[pivot - 1].pipeHoll[3] && pipesScript[pivot].pipeHoll[1])
                    {
                        pipesScript[pivot].connectedWithStart = true;
                        notConnected = true;
                    }
                }
                else if (bar1.y > bar2.y)
                {
                    if (pipesScript[pivot - 1].pipeHoll[1] && pipesScript[pivot].pipeHoll[3])
                    {
                        pipesScript[pivot].connectedWithStart = true;
                        notConnected = true;
                    }
                }
            }
                if (notConnected == false) pipesScript[pivot].connectedWithStart = false;
        }
    }
}