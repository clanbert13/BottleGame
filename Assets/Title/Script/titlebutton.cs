using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class titlebutton : MonoBehaviour
{
    public GameObject setGUI;
    public GameObject Loading;
    public GameObject Story;
    public GameObject quitGUI;
    public Text timer;
    public bool gogame = false;
    public float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        setGUI.SetActive(false);
    }
    void Update()
    {
        timer.text = "남은시간 : " + (15 - (int)time).ToString();
        time += Time.deltaTime;
        if(time > 18 && gogame)
        {
            SceneManager.LoadScene("01InGameScene");
        }
    }
    private IEnumerator StoryText()//0.5초후 텍스트 null
    {
        Story.SetActive(true);
        yield return new WaitForSeconds(15);
        Story.SetActive(false);
    }
    public void newgame()
    {
        time = 0f;
        StartCoroutine("StoryText");
        Loading.SetActive(true);
        PlayerPrefs.DeleteAll();//저장파일 모두제거후 씬 불러옴
        gogame = true;
        //SceneManager.LoadScene("01InGameScene");
    }
    public void continuegame()
    {
        Loading.SetActive(true);
        //UnityEngine.Debug.Log("이어하기");
        SceneManager.LoadScene("01InGameScene");
    }
    public void quitgame()
    {
        //UnityEngine.Debug.Log("나가기");
        quitGUI.SetActive(true);
    }
    public void yesquit()
    {
        Application.Quit();
    }
    public void noquit()
    {
        quitGUI.SetActive(false);
    }
    public void settinggame()
    {
        setGUI.SetActive(true);
    }
    public void quitsetting()
    {
        setGUI.SetActive(false);
    }
}
