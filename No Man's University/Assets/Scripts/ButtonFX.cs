using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public void HoverSound()
    {
        audioSource.PlayOneShot(hoverSound);
    }

    public void ClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }
}
