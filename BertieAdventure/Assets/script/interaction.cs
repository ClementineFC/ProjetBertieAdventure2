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
            Debug.Log("Je dialogue");
            GameManager.jeParleAvec = numeroQueteADonnerJour;
            flagDialogue = !flagDialogue;
            

            if (flagDialogue == true)
            {
                Debug.Log("Ouverture dialogue");
                backGroundDialogue.SetActive(true);
                zoneInfo.SetActive(false);
                nomPersonnage.text = nom;
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
            GameManager.nbValeurChevalier = NbvaleurChevalier + 1;
            zoneValeurChevalier.GetComponent<Text>().text = GameManager.nbValeurChevalier.ToString();

            //Faire poper la valeur
            StartCoroutine(AfficheItem());
            
            
        }
        if(leCanvas.GetComponent<QueteManager>().TabAvancementQuete[numeroQueteADonnerJour] == 3)
        {
            timer = timer + Time.deltaTime;
            if(timer >= 5.0f)
            {
                leCanvas.GetComponent<QueteManager>().TabAvancementQuete[numeroQueteADonnerJour] = 4;
            }
            
        }
        if(leCanvas.GetComponent<QueteManager>().TabAvancementQuete[numeroQueteADonnerJour] == 4)
        {
            dialogueText.text = leCanvas.GetComponent<QueteManager>().TabQueteTerminer[numeroQueteADonnerJour];
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

    }


    void repliqueSuivante()
    {
        if (GameManager.jeParleAvec == numeroQueteADonnerJour)
        {


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
                leCanvas.GetComponent<QueteManager>().zoneQuete.SetActive(false);
                valeurChevalier.SetActive(false);//Revoir ca ferme pas la fernetre de quete ! 
            }


        }
       

    }

    IEnumerator AfficheItem()
    {
            valeurChevalier.SetActive(true); //afficher un charactère de la chaine de char
            yield return new WaitForSeconds(2.0f); //faire une pause toute les 0.1s
    }


}
