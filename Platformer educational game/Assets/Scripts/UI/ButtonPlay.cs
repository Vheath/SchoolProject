using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    public void SwitchLevel(Object scene)
    {
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
        SceneManager.LoadScene("EssentialScene", LoadSceneMode.Additive);
    }
}
