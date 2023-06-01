using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject panel;
    PauseManager pauseManager;

    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panel.activeInHierarchy == false)
                OpenMenu(true);
            else
                OpenMenu(false);
        }   
    }
    public void OpenMenu(bool DoOpenMenu)
    {
        pauseManager.PauseGame(DoOpenMenu);
        panel.SetActive(DoOpenMenu);
    }
}
