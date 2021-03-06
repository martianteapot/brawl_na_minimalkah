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
    bool finish;
    public GameObject Death;
    // Start is called before the first frame update
    void Start()
    {
        push = 0;
        enRoute = false; 
        finish = false;  
    }

    // Update is called once per frame
    void Update()
    {
       if (Timer.timerIsRunning == false && finish == false)
        {
            Death.gameObject.SetActive(true);
        } 
        
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

        if (other.CompareTag("Finish") && Timer.timerIsRunning == true)
        {
            animator2.SetTrigger("endLevel");
            animator3.SetTrigger("endLevel");
            finish = true;
        }

    }

}
