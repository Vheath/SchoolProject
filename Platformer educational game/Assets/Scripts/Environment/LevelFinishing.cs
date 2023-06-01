using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinishing : MonoBehaviour
{
    public void FinishLevel()
    {
        Invoke("PlayFinishSound", 1f);
        Invoke("FinishLevelPart2", 2f);
    }
    
    private void PlayFinishSound()
    {
        GameManager.instance.audioManager.PlayFinish();
    }
    private void FinishLevelPart2()
    {

        if (SceneManager.GetActiveScene().buildIndex > SceneManager.sceneCount)
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
