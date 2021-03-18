using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordandShield : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    bool blockPossible = true;
    bool attackPossible = true;
    public GameObject mySword;
    public GameObject myShield;
    //public AudioSource playerAudioSource;

    IEnumerator shield()
    { 
        yield return new WaitForSeconds(0.3f);
        myShield.GetComponent<Collider>().enabled = false;
        HealthSystem.canTakeDamage = true;
        blockPossible = true;
    }

    IEnumerator sword()
    {
        yield return new WaitForSeconds(0.3f);
        mySword.GetComponent<Collider>().enabled = false;
        attackPossible = true;
    }
        
    public void Attack()
    { 
        if(attackPossible == true)
        {  
            mySword.GetComponent<Collider>().enabled = true;
            anim.SetTrigger("attack");
            attackPossible = false;
            StartCoroutine(sword());
        }  
    }
    
    public void Block()
    {
        if(blockPossible == true && HealthSystem.canTakeDamage == true)
        {     
        anim.SetTrigger("inBlock");
        myShield.GetComponent<Collider>().enabled = true;
        blockPossible = false;
        HealthSystem.canTakeDamage = false;
        StartCoroutine(shield());
        }         
    }  
}