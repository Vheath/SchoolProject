using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        audioSource.PlayOneShot(finishSound);
        Invoke("FinishLevelPart2", 2f);
    }
    private void FinishLevelPart2()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log(SceneManager.sceneCount);
        if (SceneManager.GetActiveScene().buildIndex + 1 > SceneManager.sceneCount)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }
        SceneManager.LoadScene("EssentialScene", LoadSceneMode.Additive);
    }
}
