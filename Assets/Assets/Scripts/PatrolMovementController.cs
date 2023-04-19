using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class PatrolMovementController : MonoBehaviour
{
    [SerializeField] private Transform[] checkpointsPatrol;
    [SerializeField] private Rigidbody2D myRBD2;
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float velocityModifier = 5f;
    private Transform currentPositionTarget;
    private int patrolPos = 0;
    [SerializeField] int puntosbonus = 1;


    [SerializeField] private Vector2 direccionraycast;
    [SerializeField] private int distanceModifier = 15;
    [SerializeField] LayerMask mylayers;



    [SerializeField] HealthBarController VidaEnemy;
    [SerializeField] int vidaacutal;


    //EVENTO 
    public event Action<int> onEnemyDestroy;



    private void Start() {
        currentPositionTarget = checkpointsPatrol[patrolPos];
        transform.position = currentPositionTarget.position;
        vidaacutal = VidaEnemy.GetCurrentValue();

    }

    private void Update() {
        CheckNewPoint();

        animatorController.SetVelocity(velocityCharacter: myRBD2.velocity.magnitude);

      
    }

    private void CheckNewPoint(){
        if(Mathf.Abs((transform.position - currentPositionTarget.position).magnitude) < 0.25){
            patrolPos = patrolPos + 1 == checkpointsPatrol.Length? 0: patrolPos+1;
            currentPositionTarget = checkpointsPatrol[patrolPos];
            myRBD2.velocity = (currentPositionTarget.position - transform.position).normalized*velocityModifier;
            CheckFlip(myRBD2.velocity.x);

            
  
        }
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, myRBD2.velocity, distanceModifier, mylayers);
        if (raycast)
        {
            Debug.Log("Detected");
            myRBD2.velocity = (currentPositionTarget.position - transform.position).normalized * (velocityModifier + 2);
        }
        else
        {
            myRBD2.velocity = (currentPositionTarget.position - transform.position).normalized * (velocityModifier);
        }
        Debug.DrawRay(transform.position, myRBD2.velocity.normalized * distanceModifier, Color.green);

    }

    private void CheckFlip(float x_Position){
        spriteRenderer.flipX = (x_Position - transform.position.x) < 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            VidaEnemy.UpdateHealth(-20);
            vidaacutal = vidaacutal - 20;
         
            if (vidaacutal <= 0)
            {
                onEnemyDestroy?.Invoke(puntosbonus);
                Destroy(gameObject);
            }
        }
    }
}
