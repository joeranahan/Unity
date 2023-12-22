using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOFlight : MonoBehaviour
{
    public float circleRadius = 5.0f;
    public float circleSpeed = 1.0f;
    private float angle = 0.0f;

    private Vector3 startPosition;
    public Light[] greenLights;
    private float flashTimer = 0.0f;
    public float flashInterval = 0.2f;
    public float spinSpeed = 30.0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // UFO Movement
        CircleMovement();

        // Flashing Lights
        FlashLights();

        SpinUFO();
    }

    void CircleMovement()
    {
        angle += circleSpeed * Time.deltaTime;
        var x = startPosition.x + Mathf.Cos(angle) * circleRadius;
        var z = startPosition.z + Mathf.Sin(angle) * circleRadius;
        transform.position = new Vector3(x, transform.position.y, z);
    }

    void FlashLights()
    {
        flashTimer += Time.deltaTime;
        if (flashTimer >= flashInterval)
        {
            foreach (Light light in greenLights)
            {
                light.enabled = !light.enabled;
            }
            flashTimer = 0.0f;
        }
    }
    void SpinUFO()
    {
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }
}