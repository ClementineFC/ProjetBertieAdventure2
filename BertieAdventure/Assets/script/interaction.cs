using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction : MonoBehaviour
{
    public DialogueScript dialogue;
    public GameObject zoneInfo;
    public GameObject backGroundDialogue;
    public bool activeInfo;
    public bool flagDialogue;

    void Start()
    {
        zoneInfo = GameObject.Find("ZoneInfo");
        backGroundDialogue = GameObject.Find("BackGroundDialigue");
        zoneInfo.SetActive(false);
        backGroundDialogue.SetActive(false);
        flagDialogue = false;

    }
    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.A))
        {

            flagDialogue = !flagDialogue;
            

            if (flagDialogue == true)
            {
                backGroundDialogue.SetActive(true);
                zoneInfo.SetActive(false);
                TriggerDialogue();
            }
        }
        if (flagDialogue == false)
        {
            zoneInfo.SetActive(true);
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    private void OnTriggerExit(Collider other)
    {
        zoneInfo.SetActive(false);
        backGroundDialogue.SetActive(false);
        flagDialogue = false;
    }

}
