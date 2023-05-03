using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDestroy : MonoBehaviour
{
    [SerializeField] private GameObject destroyFX;

    private void OnDestroy()
    {
        GameObject fx = Instantiate(destroyFX);
        fx.transform.position = transform.position;
    }


}
