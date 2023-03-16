using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptMessageDebutJeu : MonoBehaviour
{
    public Text MessageDebutJeu;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        MessageDebutJeu.text = "Bienvenue au village ! \r\nD'après les rumeurs un hermite vivrait dans la forêt, peut-être saurait-il me conseiller !";
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= 10.0f)
        {
            Debug.Log("je suis la ");
            //MessageDebutJeu.SetActive(false);
            MessageDebutJeu.text = "";
        }
    }
}
