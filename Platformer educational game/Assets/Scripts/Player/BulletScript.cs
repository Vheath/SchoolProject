using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    public Camera mainCamera;
    private Rigidbody2D rb;
    private GameObject equationBase;
    public float force;
    [SerializeField] private GameObject destroyFX;

    private void Start()
    {
        equationBase = GameObject.FindGameObjectWithTag("Equation");
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        /* Vector3 rotation = transform.position = mousePos;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90); */
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Trap") || other.gameObject.CompareTag("Ground"))
        {
            //Удаляем если сталкивается с землей или ловушкой
            GameObject fx =  GameObject.Instantiate(destroyFX);
            fx.transform.position = transform.position;
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Equation Block") || other.gameObject.CompareTag("Extra Equation Block"))
        {
            //Делаем это если попадаем в уравнение
            equationBase.GetComponent<EquationGenerator>().Choice(other.gameObject);
            Destroy(gameObject);
        }

    }
}
