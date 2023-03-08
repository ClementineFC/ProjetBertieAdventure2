using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueteManager : MonoBehaviour
{
    public GameObject zoneQuete;
    public Text textQuete;
    public Text nbObjectRamasse;
    public Text nbObjectARamasser;
    public int IndiceQueteEnCours; //Indice de quete -1 pas de quete > -1 (0.1.2.3..) quete en cours
    public string[] TabDescriptionQuete;
    public string[] TabRetourVersProtagoniste;
    public int[] TabAvancementQuete; // 0 quete non fait 1 quete vas chercher object 2 quete rend l'object 3 quete fini
    // Start is called before the first frame update
    void Start()
    {
        zoneQuete = GameObject.Find("ZoneQuete");
        textQuete = GameObject.Find("textQuete").GetComponent<Text>();
        nbObjectRamasse = GameObject.Find("nbObjectRamasse").GetComponent<Text>();
        nbObjectARamasser = GameObject.Find("nbObjectARamasser").GetComponent<Text>();

        zoneQuete.SetActive(false);
        IndiceQueteEnCours = -1; //pas de quete en cours
    }

    // Update is called once per frame
    void Update()
    {
        if(IndiceQueteEnCours == -1)
        {
            zoneQuete.SetActive(false);
            textQuete.text = "";
        }
        if(IndiceQueteEnCours > -1)
        {
            zoneQuete.SetActive(true);
            textQuete.text = TabDescriptionQuete[IndiceQueteEnCours];

        }
    }
}
