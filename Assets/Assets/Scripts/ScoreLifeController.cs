using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLifeController : MonoBehaviour
{
    public GameObject player;
    private int vida;
    PlayerController playerController;


    [SerializeField] PatrolMovementController enemy1;
    [SerializeField] ControladorOgro ogro1;

    private int puntaje = 0;
    int count = 0;




    private void Start()
    {
        vida = player.GetComponent<PlayerController>().GetVida();
        playerController = player.GetComponent<PlayerController>();

        playerController.onPlayerDamaged += HandlePlayerDamaged;
        enemy1.onEnemyDestroy += HandleEnemyDestroy;
        ogro1.onEnemyDestroy += HandleEnemyDestroy;
    }
    private void Update()
    {
        Win();
    }

    private void Win()
    {
        if(count >= 1)
        {
            Debug.Log("Ganaste");
        }
    }
    private void OnGUI()
    {
        GUI.skin.label.fontSize = 32;
        GUI.Label(new Rect(250, 90, 350, 350), string.Format("Vida Actual: {0}", vida));
        GUI.Label(new Rect(250, 50, 350, 350), string.Format("Total Score: {0}", puntaje));
    }

    private void HandlePlayerDamaged(int cantidadDaño)
    {
        vida -= cantidadDaño;
    }
    private void HandleEnemyDestroy(int bonuspuntaje)
    {
        puntaje += bonuspuntaje;
        count++;

    }
}
