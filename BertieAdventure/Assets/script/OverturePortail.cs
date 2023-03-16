using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverturePortail : MonoBehaviour
{
    public GameObject portail;
    // Start is called before the first frame update
    void Start()
    {
        portail.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if(GameManager.nbValeurChevalier== 1)
        {
            Debug.Log("J'ouvre le portail");
            portail.SetActive(false);
        }
    }
}
