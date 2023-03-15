using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class mouvement_vache : MonoBehaviour

{
    public GameObject vache;
    public NavMeshAgent agent;
    public NavMeshPath path;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetComponent<NavMeshAgent>().updatePosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.GetComponent<NavMeshAgent>().enabled = true;
        agent.SetDestination(Vector3.forward);
        agent.autoRepath = true;

    }
    private void OnAnimatorMove()
    {
        transform.position = GetComponent<NavMeshAgent>().nextPosition;
    }

}
