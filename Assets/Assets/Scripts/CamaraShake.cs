using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamaraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 0.5f;
    [SerializeField] private float shakeIntensity;
    [SerializeField] private float DisminuirShake = 1.0f;
    private Vector2 initialPosition;

    private float actualShakeDuration = 0.0f;
    private float actualShakeIntensity = 0.0f;

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        if (actualShakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitCircle * actualShakeDuration;
            actualShakeDuration -= Time.deltaTime * DisminuirShake;
            actualShakeIntensity -= Time.deltaTime * DisminuirShake;
        }
        else
        {
            actualShakeDuration = 0;
            actualShakeDuration = 0;
            transform.localPosition = initialPosition;
        }

    }
    public void ShakeCamera()
    {
        actualShakeDuration = shakeDuration;
        actualShakeIntensity = 200 / 100f;
    }
}
