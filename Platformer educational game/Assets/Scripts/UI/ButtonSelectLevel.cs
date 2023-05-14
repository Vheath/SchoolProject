using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelectLevel : MonoBehaviour
{
    
    public void OpenSelectPanel(GameObject panel)
    {
        if(panel.activeSelf)
        {
            panel.SetActive(false);
        }
        else 
        {
            panel.SetActive(true);
        }
    }
}
