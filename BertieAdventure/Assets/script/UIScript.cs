using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public Button StartButton;
    // Start is called before the first frame update
    void Start()
    {
        StartButton.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("clcik");
        SceneManager.LoadScene("Animatiques");
    }
}
