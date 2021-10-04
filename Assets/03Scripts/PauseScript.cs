using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;

    private void Start()
    {
        pauseUI.SetActive(false);
    }
    public void PauseButtonClick()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void CountinueButtonClick()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitButtonClick()
    {
        Debug.Log("Quit");
        Time.timeScale = 1f;
        SceneManager.LoadScene("00Title");
        //Application.Quit();
    }
}
