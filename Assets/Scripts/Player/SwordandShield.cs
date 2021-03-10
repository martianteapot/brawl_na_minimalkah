using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordandShield : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    bool blockPossible = true;
    [SerializeField]
    Joystick joystick;
    bool attackPossible = false;

    IEnumerator shield()
    {
        blockPossible = false;
        yield return new WaitForSeconds(1);
        inBlock();
        blockPossible = true;
    }

    IEnumerator sword()
    {
        anim.SetBool("slash", true);
        attackPossible = false;
        yield return new WaitForSeconds(1);
        inAttack();
        yield return new WaitForSeconds(1);
    }
        
    void FixedUpdate()
    { 
        Attack();   
    }
    
    public void Block()
    {
        if(blockPossible == true)
        {
        anim.SetBool("block", true);
        StartCoroutine(shield());
        return;
        }         
    }

    void Attack()
    {
        /*if(attackPossible == true && joystick.Horizontal == 0 || joystick.Vertical == 0)
        {
            //anim.SetBool("slash", true);
            StartCoroutine(sword());
        }*/ 
        
        if(joystick.Horizontal > 0 || joystick.Horizontal < 0 || joystick.Vertical > 0 || joystick.Vertical < 0)
        {
            attackPossible = true;
            StartCoroutine(sword());
        }        
    }

    public void inBlock()
    {
        anim.SetBool("block", false);    
    }

    void inAttack()
    {
        anim.SetBool("slash", false);    
    }

    

}
