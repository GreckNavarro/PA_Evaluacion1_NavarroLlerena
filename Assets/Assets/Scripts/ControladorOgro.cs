using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class ControladorOgro : MonoBehaviour
{
    [SerializeField] HealthBarController VidaEnemy;
    [SerializeField] int vidaacutal;

    [SerializeField] ControladorZona zona;
    [SerializeField] int puntajebonus = 20;



    //EVENTO 
    public event Action<int> onEnemyDestroy;


    private void Start()
    {
        vidaacutal = VidaEnemy.GetCurrentValue();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {  if (collision.gameObject.tag == "Bullet")
        {
            VidaEnemy.UpdateHealth(-20);
            vidaacutal = vidaacutal - 20;
            if (vidaacutal <= 0)
            {
                onEnemyDestroy?.Invoke(puntajebonus);
                Destroy(gameObject);
                Destroy(zona);
            }
        }
    }
}
