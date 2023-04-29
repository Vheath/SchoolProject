using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip jump, death, shot, dash, land;
    [SerializeField] AudioSource audioSource;

    public void PlayJump()
    {
        audioSource.PlayOneShot(jump);
    }

    public void PlayDeath()
    {
        audioSource.PlayOneShot(death);
    }

    public void PlayShot()
    {
        audioSource.PlayOneShot(shot);
    }
    public void PlayDash()
    {
        audioSource.PlayOneShot(dash);
    }
    public void PlayLand()
    {
        audioSource.PlayOneShot(land);
    }

}
