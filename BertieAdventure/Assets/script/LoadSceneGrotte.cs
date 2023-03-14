using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneGrotte : MonoBehaviour
{
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
        Debug.Log("Je rentre dans le ontrigger");
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("J'appuie sur A");
            SceneManager.LoadScene("GrotteNeige");
        }
    }
}
