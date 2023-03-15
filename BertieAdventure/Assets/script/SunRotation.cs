using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    public float rotationSpeed = 1.0f; // Vitesse de rotation en degrés par seconde

    void Update()
    {
        // Faire tourner l'objet autour de l'axe Y à une vitesse constante
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
