using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordandShield : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    bool blockPossible = true;
    bool attackPossible = true;
    [SerializeField]
    Joystick joystick;
    //bool attackPossible = false;
    public GameObject mySword;
    public GameObject myShield;

    IEnumerator shield()
    {
        myShield.GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        inBlock();
        myShield.GetComponent<Collider>().enabled = false;
        blockPossible = true;
    }

    IEnumerator sword()
    {
        mySword.GetComponent<Collider>().enabled = true;
        anim.SetBool("slash", true);
        yield return new WaitForSeconds(1);
        inAttack();
        mySword.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(1);
        attackPossible = true;
    }
        
    void FixedUpdate()
    { 
        if(attackPossible == true)
        {  
          if(joystick.Horizontal > 0 || joystick.Horizontal < 0 || joystick.Vertical > 0 || joystick.Vertical < 0)
        {
            attackPossible = false;
            StartCoroutine(sword());
        }
        }  
    }
    
    public void Block()
    {
        if(blockPossible == true)
        {
        anim.SetBool("block", true);
        StartCoroutine(shield());
        blockPossible = false;
        return;
        }         
    }

    //void Attack()
    //{
        /*if(attackPossible == true && joystick.Horizontal == 0 || joystick.Vertical == 0)
        {
            //anim.SetBool("slash", true);
            StartCoroutine(sword());
        }*/ 
        
             
    //}

    public void inBlock()
    {
        anim.SetBool("block", false);    
    }

    void inAttack()
    {
        
        anim.SetBool("slash", false);    
    }

    

}
