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
    public bool flagTimer;

    public int numeroQueteADonnerJour;
    public int compteur;
    public int NbvaleurChevalier;

    public float timer;

    public Text nomPersonnage;
    public Text dialogueText;
    public GameObject zoneValeurChevalier;
    public GameObject leCanvas;
    public GameObject valeurChevalier;
 

    public int IndexSentences;

    void Start()
    {
        zoneInfo.SetActive(false);
        backGroundDialogue.SetActive(false);
        flagDialogue = false;
        flagTimer = false;
        boutonSuivant.GetComponent<Button>().onClick.AddListener(repliqueSuivante);
        IndexSentences = 0;
        compteur = 0;
        NbvaleurChevalier = 0;
        timer = 0.0f;
        valeurChevalier.SetActive(false);

    }
    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            
            GameManager.jeParleAvec = numeroQueteADonnerJour;
            flagDialogue = !flagDialogue;
            

            if (flagDialogue == true)
            {
                backGroundDialogue.SetActive(true);
                zoneInfo.SetActive(false);
                dialogueText.text = sentences[IndexSentences];

            }

            if (flagDialogue == false)
            {
                zoneInfo.SetActive(true);

            }

        }

        if (flagDialogue == false)
        {
            zoneInfo.SetActive(true);

        }
        if (compteur > 1 && leCanvas.GetComponent<QueteManager>().TabNbObjectRammase[numeroQueteADonnerJour] == leCanvas.GetComponent<QueteManager>().TabMaxObjRamasser[numeroQueteADonnerJour] && Input.GetKeyDown(KeyCode.A))
        {

            leCanvas.GetComponent<QueteManager>().TabAvancementQuete[numeroQueteADonnerJour] = 3;
            dialogueText.text = leCanvas.GetComponent<QueteManager>().TabReponseFinQuete[numeroQueteADonnerJour];
        }
        compteur++;
    }
  
    private void OnTriggerExit(Collider other)
    {
        zoneInfo.SetActive(false);
        backGroundDialogue.SetActive(false);
        flagDialogue = false;
        dialogueText.text = "";
        IndexSentences = 0;
        if (leCanvas.GetComponent<QueteManager>().TabAvancementQuete[numeroQueteADonnerJour] == 4)
        {
            NbvaleurChevalier = NbvaleurChevalier + 1;
            Debug.Log("NbvaleurChevalier " + NbvaleurChevalier);
            zoneValeurChevalier.GetComponent<Text>().text = NbvaleurChevalier.ToString();
            //Faire poper la valeur
            valeurChevalier.SetActive(false);

        }

    }


    void repliqueSuivante()
    {
        if (GameManager.jeParleAvec == numeroQueteADonnerJour)
        {
           // Debug.Log("Replique suivante : " + GameManager.nbclic + "Je donne la quete n°" + numeroQueteADonnerJour + "Je parle avec le perso qui a la quete n°" + GameManager.jeParleAvec);
           // GameManager.nbclic++;


            if (IndexSentences >= sentences.Length- 1) // cas fin du dialogue
            {
                Debug.Log("fin du dialogue");
                leCanvas.GetComponent<QueteManager>().IndiceQueteEnCours = numeroQueteADonnerJour; // la quete en cours est donné par le PNJ
                leCanvas.GetComponent<QueteManager>().TabAvancementQuete[numeroQueteADonnerJour] = 0; // on donne la quete au joueur (avancement 0 = debut quete sinon moins -1 )
                leCanvas.GetComponent<QueteManager>().zoneQuete.SetActive(true);
                backGroundDialogue.SetActive(false); // on deactive la zone de dialogue
               
            }
            else // cas normal de dialogue
            {

                IndexSentences++;
                dialogueText.text = sentences[IndexSentences];
            }
            if (compteur > 1 && leCanvas.GetComponent<QueteManager>().TabNbObjectRammase[numeroQueteADonnerJour] == leCanvas.GetComponent<QueteManager>().TabMaxObjRamasser[numeroQueteADonnerJour])
            {

                backGroundDialogue.SetActive(false);
                leCanvas.GetComponent<QueteManager>().zoneQuete.SetActive(false); //Revoir ca ferme pas la fernetre de quete ! 
            }
            if (leCanvas.GetComponent<QueteManager>().TabAvancementQuete[numeroQueteADonnerJour] == 3)
            {
                timer = timer + Time.deltaTime;
                valeurChevalier.SetActive(true);
                if (timer >= 5.0f)
                {
                    leCanvas.GetComponent<QueteManager>().TabAvancementQuete[numeroQueteADonnerJour] = 4;
                }

            }
           


        }
       

    }
     



}
