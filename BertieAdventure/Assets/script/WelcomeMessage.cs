using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeMessage : MonoBehaviour
{
    public float displayTime = 5.0f; // Durée d'affichage du message en secondes
    public Text messageText; // Référence au composant Text qui affiche le message

    void Start()
    {
        // Afficher le message de bienvenue
        messageText.text = "Bienvenue au village !";

        // Démarrer une coroutine pour masquer le message après un certain temps
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