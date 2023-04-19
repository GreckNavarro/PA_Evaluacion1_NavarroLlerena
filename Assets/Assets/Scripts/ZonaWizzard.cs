using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaWizzard : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float tiempoEntreDisparos = 2f;
    private float tiempoSiguienteDisparo = 0f;
    public GameObject prefab;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Time.time >= tiempoSiguienteDisparo)
            {
                Disparar();
                tiempoSiguienteDisparo = Time.time + tiempoEntreDisparos;
            }
        }
    }

    private void Disparar()
    {
        Vector3 direccion = player.transform.position - transform.position;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angulo, Vector3.forward);

        GameObject bala = Instantiate(prefab, transform.position, rotation);
        bala.GetComponent<BulletEnemy>().SetTarget(player.transform.position);
        Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();
        rbBala.AddForce(direccion.normalized * 10f, ForceMode2D.Impulse);
        

    }
}

