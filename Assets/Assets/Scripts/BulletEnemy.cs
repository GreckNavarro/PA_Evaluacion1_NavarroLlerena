using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
  
    public float speed = 10f; 

    private Vector3 targetPosition; // Posición del objetivo al momento de disparar
    private Vector3 moveDirection; // Dirección de movimiento de la bala
    [SerializeField] Rigidbody2D rb;

    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = moveDirection * speed;
    }



    public void SetTarget(Vector3 target)
    {
        targetPosition = target; 
        moveDirection = (targetPosition - transform.position).normalized; 
        transform.rotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject); 
        }
        else if (collision.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
    }
}

  

