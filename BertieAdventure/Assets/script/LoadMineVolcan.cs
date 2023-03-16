using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMineVolcan : MonoBehaviour
{
    public GameObject ZoneInfo;
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("MineVolcan");

        }
    }
    private void OnTriggerExit(Collider other)
    {
        ZoneInfo.SetActive(false);
    }
}