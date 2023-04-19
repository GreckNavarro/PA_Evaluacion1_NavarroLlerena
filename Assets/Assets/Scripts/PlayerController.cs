using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRBD2;
    [SerializeField] private float velocityModifier = 5f;
    [SerializeField] private float rayDistance = 10f;
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] GameObject Prefabs;
    [SerializeField] GameObject controladordisparo;
    [SerializeField] HealthBarController VidaPlayer;
    [SerializeField] CamaraShake camara;

    
    int vidaacutal = 100;
    public Vector2 mouseInput;


    //Eventos
    public UnityEvent OnDestroyPlayer;
    public delegate void UnityAction();
    public event Action<int> onPlayerDamaged;




    private void Start()
    {
        vidaacutal = VidaPlayer.GetCurrentValue();
    }
    private void Update() {
        Vector2 movementPlayer = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        myRBD2.velocity = movementPlayer * velocityModifier;

        animatorController.SetVelocity(velocityCharacter: myRBD2.velocity.magnitude);

         mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        CheckFlip(mouseInput.x);
    
        Debug.DrawRay(transform.position, mouseInput.normalized * rayDistance, Color.red);

        if(Input.GetMouseButtonDown(0)){

            GameObject Bullet = Instantiate(Prefabs, controladordisparo.transform.position, controladordisparo.transform.rotation);
            Bullet.GetComponent<Bullet>().SetPlayer(this);
            
        }else if(Input.GetMouseButtonDown(1)){
            Debug.Log("Left Click");
        }
    }

    public Vector2  GetVector(Vector2 direccion)
    {
        direccion = mouseInput;
        return direccion;
    }
    public int GetVida()
    {
        return vidaacutal;
    }
    private void CheckFlip(float x_Position){
        spriteRenderer.flipX = (x_Position - transform.position.x) < 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            VidaPlayer.UpdateHealth(-20);
            vidaacutal = vidaacutal - 20;
            camara.ShakeCamera();
            onPlayerDamaged?.Invoke(20);
            if (vidaacutal <= 0)
            {
                Destroy(gameObject);
            }
        }

        else if (collision.gameObject.tag == "BulletEnemy")
        {
            VidaPlayer.UpdateHealth(-20);
            vidaacutal = vidaacutal - 20;
            camara.ShakeCamera();
            onPlayerDamaged?.Invoke(20);
            if (vidaacutal <= 0)
            {
                Destroy(gameObject);
            }
        }
        

        else if (collision.gameObject.tag == "Walls")
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        OnDestroyPlayer.Invoke();
    }
}
