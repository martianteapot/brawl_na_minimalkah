using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackPlayer : MonoBehaviour
{
    private Transform target;
    public GameObject orc;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Player").transform;
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = target.position;             
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            Destroy(orc);
        }
    }
}
