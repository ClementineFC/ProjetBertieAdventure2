using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction : MonoBehaviour
{
    public DialogueScript dialogue;
    //public Animator animator;
    private void OnTriggerStay(Collider other)
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
            TriggerDialogue();
           // animator.SetBool("isOpen", true);
        //}
            
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    private void OnTriggerExit(Collider other)
    {
        //animator.SetBool("isOpen", false);
    }
}
