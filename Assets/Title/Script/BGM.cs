using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM : MonoBehaviour
{
    public Text Vol;
    public AudioSource audioSource;
    public float volume = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        volume = PlayerPrefs.GetFloat("volume", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = volume / 10;
        Vol.text = "소리크기 : " + volume;
    }
    public void volumedown()
    {
        if(volume > 0)
        {
            UnityEngine.Debug.Log("volume down");
            volume -= 1;
            PlayerPrefs.SetFloat("volume", volume);
        }
    }
    public void volumeup()
    {
        if(volume < 10)
        {
            UnityEngine.Debug.Log("volume up");
            volume += 1;
            PlayerPrefs.SetFloat("volume", volume);
        }
    }
}
