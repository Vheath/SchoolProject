using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour
{
    [SerializeField] private GameObject destroyFX;

    public void DestroyWithFX()
    {
        GameObject fx = Instantiate(destroyFX);
        fx.transform.position = transform.position;
        Destroy(gameObject);
    }


}
