using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public GameObject heal;
    public int life;
    private Animator anim;
    Collider myCollider;
    bool canDie = true;
    public GameObject Movement;
    

    IEnumerator hit()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("hit", false);
    }
    IEnumerator death()
    {
        anim.SetTrigger("die");
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator powerup()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("heal", false);
    }
    // Update is called once per frame
    void Start()
    {
        anim = GetComponent<Animator>();
        myCollider = gameObject.GetComponent<Collider>();   
         
    }
    
    void FixedUpdate()
    {
        if(life < 1)
        {
            hearts[0].gameObject.SetActive(false);
            //Destroy(hearts[0].gameObject);
        } 
        else if (life < 2)
        {
            hearts[1].gameObject.SetActive(false);
            //Destroy(hearts[1].gameObject);
        }
        else if (life < 3)
        {
            hearts[2].gameObject.SetActive(false);
            //Destroy(hearts[2].gameObject);
        }
        else if (life < 4)
        {
            hearts[3].gameObject.SetActive(false);
            //Destroy(hearts[3].gameObject);
        }
        else if (life < 5)
        {
            hearts[4].gameObject.SetActive(false);
            //Destroy(hearts[4].gameObject);
        }
        else if (life < 6)
        {
            hearts[5].gameObject.SetActive(false);
            //Destroy(hearts[5].gameObject);
        }
        
        if(life <= 0 && canDie == true)
        {
            myCollider.enabled = false;
            canDie = false;
            Destroy(Movement);
            StartCoroutine(death());
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    
        }
    }

    public void TakeDamage(int d) {
        {
            //hearts[life-1].gameObject.SetActive(false);
            life -= d;
        }
    }

    public void PowerUp(int d) {
        {
            life += d;
            hearts[life-1].gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spike") && life > 0)
        {
            TakeDamage(1);
            anim.SetBool("hit", true);
            StartCoroutine(hit());
        }
        
        if (other.CompareTag("Heal"))
        {
            PowerUp(1);
            Destroy(heal);
            anim.SetBool("heal", true);
            StartCoroutine(powerup());
        }

    }
}
