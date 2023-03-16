using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillOnPlane : MonoBehaviour
{

    public Button boutonRestart;
    public GameObject GameOverBackGround;
    void start()
    {
        GameOverBackGround.SetActive(false);
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Bertie")
        {
            GameOverBackGround.SetActive(true);
            boutonRestart.GetComponent<Button>().onClick.AddListener(TaskOnClick);
            Debug.Log("Bertie ne sait pas nager");
        }
    }
    void TaskOnClick()
    {
        Debug.Log("clcik");
        SceneManager.LoadScene("TestProg");
    }
}
