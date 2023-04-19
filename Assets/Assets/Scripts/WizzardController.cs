using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class WizzardController : MonoBehaviour
{
    [SerializeField] HealthBarController VidaEnemy;
    [SerializeField] int vida = 100;

    [SerializeField] ZonaWizzard zona;
    [SerializeField] int puntajebonus = 3;



    //EVENTO 
    public event Action<int> onEnemyDestroy;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            VidaEnemy.UpdateHealth(-10);
            vida = vida - 10;
            if (vida <= 0)
            {
                onEnemyDestroy?.Invoke(puntajebonus);
                Destroy(gameObject);
                Destroy(zona);
            }
        }
    }
}

