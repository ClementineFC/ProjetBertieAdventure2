using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nomPersonnage;
    public Text dialogueText;
    private GameObject leCanvas;
   
    private Queue<string> reponse;
    // Start is called before the first frame update
    void Start()
    {
        reponse = new Queue<string>();
        leCanvas = GameObject.Find("Canvas");


    }
    public void StartDialogue(DialogueScript dialogue)
    {
        Debug.Log("Debut du dialogue avec  " + dialogue.nom);
        
        nomPersonnage.text = dialogue.nom;

        reponse.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            reponse.Enqueue(sentence);
        }
        repliqueSuivante();
    }
    public void repliqueSuivante()
    {
        if(reponse.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = reponse.Dequeue();

        dialogueText.text = sentence;
    }
    public void EndDialogue()
    {
        Debug.Log("Fin dialogue");
        leCanvas.GetComponent<QueteManager>().IndiceQueteEnCours = 0;
    }

}
