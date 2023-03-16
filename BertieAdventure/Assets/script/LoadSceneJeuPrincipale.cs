using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneJeuPrincipale : MonoBehaviour
{
    public GameObject ZoneInfo;
    // Start is called before the first frame update
    void Start()
    {
        ZoneInfo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        ZoneInfo.GetComponent<Text>().text = "Appuie sur A pour Sortir";
        ZoneInfo.SetActive(true);

        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("TestProg");

        }
    }
    private void OnTriggerExit(Collider other)
    {
        ZoneInfo.SetActive(false);
    }
}