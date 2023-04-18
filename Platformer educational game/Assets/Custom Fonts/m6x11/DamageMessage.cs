using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMessage : MonoBehaviour
{
    [SerializeField] float  timeToLive = 2f;
    [SerializeField] float timeToLeave = 2f;
    private void OnEnable()
    {
        timeToLeave = timeToLive;
    }
    private void Update()
    {
        timeToLeave -= Time.deltaTime;
        if (timeToLeave < 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
