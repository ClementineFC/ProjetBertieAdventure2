using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeMessage : MonoBehaviour
{
    public float displayTime = 5.0f; // Dur�e d'affichage du message en secondes
    public Text messageText; // R�f�rence au composant Text qui affiche le message

    void Start()
    {
        // Afficher le message de bienvenue
        messageText.text = "Bienvenue au village !";

        // D�marrer une coroutine pour masquer le message apr�s un certain temps
        StartCoroutine(HideMessage());
    }

    IEnumerator HideMessage()
    {
        // Attendre le temps d'affichage du message
        yield return new WaitForSeconds(displayTime);

        // Masquer le message
        Debug.Log("Text");
        messageText.text = "Text";
    }
}