using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nomPersonnage;
    public Text dialogueText;
    public Animator animator;
    private Queue<string> reponse;
    // Start is called before the first frame update
    void Start()
    {
        reponse = new Queue<string>();
       
    }
    public void StartDialogue(DialogueScript dialogue)
    {
        animator.SetBool("isOpen", true);
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
        animator.SetBool("isOpen", false);
    }

}
