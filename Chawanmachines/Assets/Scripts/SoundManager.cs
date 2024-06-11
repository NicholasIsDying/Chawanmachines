using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;

    [Header("Audio Clips")]
    public AudioClip buttonClick;
    public AudioClip openSpeechMenu;
    public AudioClip clickSpeechMenuOptions;
    

    public void Audio_ButtonClick()
    {
        audioSource.PlayOneShot(buttonClick);
    } 

    public void Audio_OpenSpeechMenu()
    {
        audioSource.PlayOneShot(openSpeechMenu);
    }

    public void Audio_ClickSpeechMenuOptions()
    {
        audioSource.PlayOneShot(clickSpeechMenuOptions);
    }
}
