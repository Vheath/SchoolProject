using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private void Start()
    {
        PauseGame(false);
    }
    public void PauseGame(bool PauseGame)
    {
        if (PauseGame) Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }


}
