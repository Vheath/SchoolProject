using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinishing : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip finishSound;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    public void FinishLevel()
    {
        audioSource.clip = finishSound;
        audioSource.Play();
    }
}
