using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trolley : MonoBehaviour
{
    public Animator animator;
    private int push; 
    public bool enRoute;
    public Animator animator2;
    public Animator animator3;
    // Start is called before the first frame update
    void Start()
    {
        push = 0;
        enRoute = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Push") && enRoute == false)
        {
            enRoute = true;
            push += 1;
            animator.SetInteger("WayOfTrolley", push);
        }

        if (other.CompareTag("Stop"))
        {
            enRoute = false;
        }

        if (other.CompareTag("Finish"))
        {
            animator2.SetTrigger("endLevel");
            animator3.SetTrigger("endLevel");
        }

    }

}
