using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorOgro : MonoBehaviour
{

    [SerializeField] ControladorZona zona;
    private void OnTriggerEnter2D(Collider2D collision)
    {  if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(zona);
        }
    }
}
