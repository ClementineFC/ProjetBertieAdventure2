using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneGrotte : MonoBehaviour
{
    public GameObject ZoneInfo;
    //public GameObject valeurChevalier;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        ZoneInfo.GetComponent<Text>().text = "Appuie sur A pour entrer";
        ZoneInfo.SetActive(true);
        //valeurChevalier.GetComponent<Text>().text = GameManager.nbValeurChevalier.ToString();
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("GrotteNeige");
            //DontDestroyOnLoad(valeurChevalier);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        ZoneInfo.SetActive(false);
    }
}
