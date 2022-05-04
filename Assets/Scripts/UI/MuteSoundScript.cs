using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteSoundScript : MonoBehaviour
{
    private Sprite soundOn;
    public Sprite soundOff;
    public Button button;
    private bool isOn = true;

    public AudioListener AudioListener;
     void Start()
    {
        soundOn = button.image.sprite;
    }

    public void ButtonClicked()
    {
        if (isOn)
        {
            button.image.sprite = soundOff;
            isOn = false;
            AudioListener.volume = 0;
        }
        else
        {
            button.image.sprite = soundOn;
            isOn = true;
            AudioListener.volume = 1;
        }
    }
}
