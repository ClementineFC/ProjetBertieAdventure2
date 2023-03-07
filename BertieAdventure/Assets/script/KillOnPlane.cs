using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnPlane : MonoBehaviour
{
    public LayerMask planeLayer; // couche de plane

    void OnCollisionEnter(Collision collision)
    {
        // Vérifie si la collision a lieu avec un plane
        if (IsOnPlane(collision.gameObject))
        {
            // Tue le personnage
            Debug.Log("Le personnage est tombé dans l'eau. Il est mort.");
            KillPlayer();
        }
    }

    bool IsOnPlane(GameObject other)
    {
        // Vérifie si l'objet est sur la couche de plane
        return ((1 << other.layer) & planeLayer) != 0;
    }

    void KillPlayer()
    {
        // Fait quelque chose pour tuer le personnage (par exemple, désactive le GameObject)
        gameObject.SetActive(false);
    }
}
