using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScreenScript : MonoBehaviour
{
    private float rMoveAmmount = 20f;
    public float screenNo = 2f;
    [SerializeField] private float screens = 3f;
    [SerializeField] private GameObject bottlePick;
    [SerializeField] private GameObject counter;
    [SerializeField] private GameObject factory;
    [SerializeField] private GameObject lButton;
    [SerializeField] private GameObject rButton;
    private void Awake()
    {
        bottlePick.SetActive(false);
        counter.SetActive(false);
    }

    public void ScreenChangeButtonClick(string input)
    {
        switch (input)
        {
            case "R":
                if (screenNo < screens)
                {
                    screenNo++;
                    transform.Translate(new Vector2(rMoveAmmount, 0));
                }
                break;
            case "L":
                if (screenNo > 1)
                {
                    screenNo--;
                    transform.Translate(new Vector2(rMoveAmmount * -1, 0));
                }
                break;
        }
        if (screenNo == 1)
        {
            counter.SetActive(true);
            factory.SetActive(false);
            lButton.SetActive(false);
        }
        else if (screenNo == 3)
        {
            rButton.SetActive(false);
            factory.SetActive(false);
            bottlePick.SetActive(true);
        }
        else
        {
            lButton.SetActive(true);
            rButton.SetActive(true);
            factory.SetActive(true);
            counter.SetActive(false);
            bottlePick.SetActive(false);
        }
    }
}
