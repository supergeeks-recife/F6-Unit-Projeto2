using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; ;
        agent.updateUpAxis = false;
        target = GameObject.FindObjectOfType<Player>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && target == null)
        {
            target = collision.gameObject.transform;
            agent.isStopped = false;
            Debug.Log("O Player esta aqui!!! Pega ele!");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target = null;
            agent.isStopped = true;
        }
    }
}
