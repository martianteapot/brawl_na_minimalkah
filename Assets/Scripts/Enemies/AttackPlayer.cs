using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackPlayer : MonoBehaviour
{
    private Transform target;
    public GameObject orc;
    [SerializeField]
    Animator anim;
    private bool deadman = false;
    public GameObject orcSword;
    public bool canAttack;
    // Start is called before the first frame update
    IEnumerator sword()
    {
        canAttack = false;
        anim.SetBool("isAttack", true);
        orcSword.GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(1.5f);
        orcSword.GetComponent<Collider>().enabled = false;
        anim.SetBool("isAttack", false);
        yield return new WaitForSeconds(5);
        canAttack = true;
    }

    IEnumerator gethit()
    {
        anim.SetBool("getHit", true);
        transform.Translate(Vector3.back);
        yield return new WaitForSeconds(.5f);
        transform.Translate(Vector3.zero);
        anim.SetBool("getHit", false);
    }

    IEnumerator dieorc()
    {
        yield return new WaitForSeconds(2);
        Destroy(orc);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        target = GameObject.Find("Player").transform;
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if(deadman == false)
        {
            agent.destination = target.position; 
        }

        if(deadman == false && canAttack == true)
        {
            StartCoroutine(sword()); 
        }

    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            anim.SetTrigger("die");
            deadman = true;
            StartCoroutine(dieorc()); 
            
        }

        if (other.CompareTag("Shield"))
        {
            StartCoroutine(gethit());
            
        }

    }
}
