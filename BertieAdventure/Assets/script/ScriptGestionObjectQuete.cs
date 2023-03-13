using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGestionObjectQuete : MonoBehaviour
{
    public int numeroQuete;
    private GameObject leCanvas;
    public GameObject piece;



    // Start is called before the first frame update
    void Start()
    {
        leCanvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object touché ! ");
        if (numeroQuete == leCanvas.GetComponent<QueteManager>().IndiceQueteEnCours)
        {
            
           
           

            if (leCanvas.GetComponent<QueteManager>().TabNbObjectRammase[numeroQuete] < leCanvas.GetComponent<QueteManager>().TabMaxObjRamasser[numeroQuete])
            {
                leCanvas.GetComponent<QueteManager>().TabAvancementQuete[numeroQuete] = 1; // Je suis dans l'avancement 1 : chercher les objets
                Destroy(piece);
                leCanvas.GetComponent<QueteManager>().TabNbObjectRammase[numeroQuete]++;
                //leCanvas.GetComponent<QueteManager>().nbObjectRamasse.text = leCanvas.GetComponent<QueteManager>().TabNbObjectRammase[numeroQuete].ToString();
                // CAR c'est dans l'update ... du QueteManager
            }

            if (leCanvas.GetComponent<QueteManager>().TabNbObjectRammase[numeroQuete] == leCanvas.GetComponent<QueteManager>().TabMaxObjRamasser[numeroQuete])
            {
                leCanvas.GetComponent<QueteManager>().TabAvancementQuete[numeroQuete] = 2; // Je suis dans l'avancement 2 : j'ai trouvé tous les objets et je dois retourner voir le PNJ
                
            }

            if (leCanvas.GetComponent<QueteManager>().TabNbObjectRammase[numeroQuete] >= leCanvas.GetComponent<QueteManager>().TabMaxObjRamasser[numeroQuete])
            {
                Debug.Log("Nous avons pris tous les objets de la quete.");
            }


        }
        else
        {
            Debug.Log("Cette object ne fait pas partie de la quete en cours");
        }

        if(leCanvas.GetComponent<QueteManager>().TabNbObjectRammase[numeroQuete] == leCanvas.GetComponent<QueteManager>().TabMaxObjRamasser[numeroQuete])
        {
           leCanvas.GetComponent<QueteManager>().TabAvancementQuete[numeroQuete] = 2;
           leCanvas.GetComponent<QueteManager>().textQuete.text = leCanvas.GetComponent<QueteManager>().TabRetourVersProtagoniste[numeroQuete];
        }

    }

}
