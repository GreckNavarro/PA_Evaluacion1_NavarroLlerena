using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreLifeController : MonoBehaviour
{
    public GameObject player;
    private int vida;
    PlayerController playerController;


    [SerializeField] PatrolMovementController enemy1;
    [SerializeField] ControladorOgro ogro1;
    [SerializeField] WizzardController mago1;
    public UnityEvent OnWinner;

    private int nivel = 0;




    private void Start()
    {
        vida = player.GetComponent<PlayerController>().GetVida();
        playerController = player.GetComponent<PlayerController>();

        playerController.onPlayerDamaged += HandlePlayerDamaged;
        enemy1.onEnemyDestroy += HandleEnemyDestroy;
        ogro1.onEnemyDestroy += HandleEnemyDestroy;
        mago1.onEnemyDestroy += HandleEnemyDestroy;
    }
    private void Update()
    {
        Win();
    }

    private void Win()
    {
        if(nivel >= 6)
        {
            OnWinner.Invoke();
        }
    }
    private void OnGUI()
    {
        GUI.skin.label.fontSize = 32;
        GUI.Label(new Rect(250, 90, 350, 350), string.Format("Vida Actual: {0}", vida));
        GUI.Label(new Rect(250, 50, 350, 350), string.Format("Nivel Actual: {0}", nivel));
    }

    private void HandlePlayerDamaged(int cantidadDaño)
    {
        vida -= cantidadDaño;
    }
    private void HandleEnemyDestroy(int bonuspuntaje)
    {
        nivel += bonuspuntaje;

    }
}
