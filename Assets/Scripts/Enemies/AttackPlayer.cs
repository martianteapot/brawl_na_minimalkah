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
        yield return new WaitForSeconds(.5f);
        if(deadman == false){
            anim.SetTrigger("inAttack");
            orcSword.GetComponent<Collider>().enabled = true;
            }
        canAttack = false;
        yield return new WaitForSeconds(1.5f);
        orcSword.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(1);
        canAttack = true;
    }

    IEnumerator gethit()
    {
        transform.Translate(Vector3.back);
        yield return new WaitForSeconds(.5f);
        transform.Translate(Vector3.zero);
    }

    IEnumerator dieorc()
    {
        yield return new WaitForSeconds(3);
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
            anim.SetTrigger("inHit");
            StartCoroutine(gethit());
        }

        if (other.CompareTag("HitBox"))
        {
            
            StartCoroutine(sword());
        }

    }
}
