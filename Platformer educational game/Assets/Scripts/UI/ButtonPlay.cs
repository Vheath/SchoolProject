using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    public void SwitchLevel(int scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
