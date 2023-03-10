using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interaction : MonoBehaviour
{
 
    public string nom;
    [TextArea(3, 10)]
    public string[] sentences;
    public GameObject zoneInfo;
    public GameObject backGroundDialogue;
    public Button boutonSuivant;
    public bool activeInfo;
    public bool flagDialogue;
    public int numeroQueteADonnerJour;

    public Text nomPersonnage;
    public Text dialogueText;
    public GameObject leCanvas;
 

    public int IndexSentences;

    void Start()
    {
        zoneInfo.SetActive(false);
        backGroundDialogue.SetActive(false);
        flagDialogue = false;
        boutonSuivant.GetComponent<Button>().onClick.AddListener(repliqueSuivante);
        IndexSentences = 0;

    }
    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.A))
        {

            flagDialogue = !flagDialogue;
            

            if (flagDialogue == true)
            {
                backGroundDialogue.SetActive(true);
                zoneInfo.SetActive(false);
                //StartDialogue(dialogue);
                dialogueText.text = sentences[IndexSentences];

            }
        }
        if (flagDialogue == false)
        {
            zoneInfo.SetActive(true);

        }
    }
  
    private void OnTriggerExit(Collider other)
    {
        zoneInfo.SetActive(false);
        backGroundDialogue.SetActive(false);
        flagDialogue = false;
        dialogueText.text = "";
        IndexSentences = 0;
    }



    public void repliqueSuivante()
    {

        if(IndexSentences < sentences.Length)
        {
            
            dialogueText.text = sentences[IndexSentences];
            IndexSentences++;
        }
        else //Fin dialogue
        {
            backGroundDialogue.SetActive(false);
            leCanvas.GetComponent<QueteManager>().IndiceQueteEnCours = numeroQueteADonnerJour;
        }
       

    }
    




}
