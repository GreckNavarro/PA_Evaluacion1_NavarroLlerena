using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int velocidad = 5;
    [SerializeField] PlayerController player;
    [SerializeField] Vector2 direccion;
    [SerializeField] Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Walls")
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayer(PlayerController newplayer)
    {
        player = newplayer;
        direccion = player.GetComponent<PlayerController>().GetVector(direccion);
        rb.velocity = direccion * velocidad;
    }
}
