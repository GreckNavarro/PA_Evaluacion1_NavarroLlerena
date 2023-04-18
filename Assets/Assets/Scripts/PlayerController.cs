using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRBD2;
    [SerializeField] private float velocityModifier = 5f;
    [SerializeField] private float rayDistance = 10f;
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] GameObject Prefabs;
    [SerializeField] GameObject controladordisparo;

     public Vector2 mouseInput;

    private void Update() {
        Vector2 movementPlayer = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        myRBD2.velocity = movementPlayer * velocityModifier;

        animatorController.SetVelocity(velocityCharacter: myRBD2.velocity.magnitude);

         mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        CheckFlip(mouseInput.x);
    
        Debug.DrawRay(transform.position, mouseInput.normalized * rayDistance, Color.red);

        if(Input.GetMouseButtonDown(0)){

            Debug.Log("Right Click");
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
    private void CheckFlip(float x_Position){
        spriteRenderer.flipX = (x_Position - transform.position.x) < 0;
    }
}
