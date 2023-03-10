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
            
            leCanvas.GetComponent<QueteManager>().TabAvancementQuete[numeroQuete] = 1; // 1 je peux recupere l'objet de la quete en cours
            Destroy(piece);
            leCanvas.GetComponent<QueteManager>().TabNbObjectRammase[numeroQuete]++;
            leCanvas.GetComponent<QueteManager>().nbObjectRamasse.text = leCanvas.GetComponent<QueteManager>().TabNbObjectRammase[numeroQuete].ToString();


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
