using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private bool canFire;
    [SerializeField] private float timeBetweenFiring;
    private Camera mainCamera;
    private Transform player;
    private float timer;
    private Vector3 mousePos;
    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameManager.instance.playerTransform;
        bullet.GetComponent<BulletScript>().mainCamera = mainCamera;
    }
    private void Update()
    {
        if (player.localScale.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (player.localScale.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;

            GameManager.instance.audioManager.PlayShot();
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }
}
