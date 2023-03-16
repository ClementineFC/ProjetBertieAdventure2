using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public Button StartButton;
    public GameObject soundboutonClick;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        soundboutonClick.GetComponent<AudioSource>().Stop();
        StartButton.GetComponent<Button>().onClick.AddListener(TaskOnClick); 
    }

    void TaskOnClick()
    {
        Debug.Log("clcik");
        soundboutonClick.GetComponent<AudioSource>().Play();
        
    }
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= 3.0f)
        {
            StartCoroutine(LancerCinematique());
        }
    }
    IEnumerator LancerCinematique()
    {
        SceneManager.LoadScene("Animatique");
        yield return new WaitForSeconds(5.0f); //faire une pause toute les 0.1s
    }
}
