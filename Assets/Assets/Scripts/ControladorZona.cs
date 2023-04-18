using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorZona : MonoBehaviour
{
    [SerializeField] GameObject ogro;
    [SerializeField] PlayerController player;
    [SerializeField] Rigidbody2D rbogro;
    private Vector2 resultante;
    private Vector2 posicioninicial;
    private bool Detected = false;

    private void Start()
    {
        posicioninicial = ogro.transform.position;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        resultante = player.transform.position - ogro.transform.position;
        if (collision.gameObject.tag == "Player")
        {
            Detected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Detected = false;
    }

    private void Update()
    {
      if (Detected == true)
      {
            rbogro.velocity = resultante;
      }
      else if (Detected == false)
      {
            ogro.transform.position = posicioninicial;
      }
    }

}
