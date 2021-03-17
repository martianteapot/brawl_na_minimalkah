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
    public GameObject Death;
    public static bool canTakeDamage = true;

    IEnumerator hit()
    {
        anim.SetBool("hit", true);
        TakeDamage(2);
        transform.Translate(Vector3.back * 0.5f);
        yield return new WaitForSeconds(.1f);
        transform.Translate(Vector3.zero);
        anim.SetBool("hit", false);
        canTakeDamage = true;
    }

    IEnumerator hit1()
    {
        anim.SetBool("hit", true);
        TakeDamage(1);
        transform.Translate(Vector3.back * 0.5f);
        yield return new WaitForSeconds(.1f);
        transform.Translate(Vector3.zero);
        anim.SetBool("hit", false);
        canTakeDamage = true;
    }

    IEnumerator death()
    {
        anim.SetTrigger("die");
        yield return new WaitForSeconds(1);
        Death.gameObject.SetActive(true);
        Time.timeScale = 0;
        
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
            hearts[1].gameObject.SetActive(false);
            hearts[2].gameObject.SetActive(false);
            hearts[3].gameObject.SetActive(false);
            hearts[4].gameObject.SetActive(false);
            hearts[5].gameObject.SetActive(false);
            hearts[6].gameObject.SetActive(false);
            hearts[7].gameObject.SetActive(false);
            hearts[8].gameObject.SetActive(false);
            hearts[9].gameObject.SetActive(false);
            hearts[10].gameObject.SetActive(false);
            hearts[11].gameObject.SetActive(false);
            
        } 
        else if (life < 2)
        {
            hearts[1].gameObject.SetActive(false);
            hearts[2].gameObject.SetActive(false);
            hearts[3].gameObject.SetActive(false);
            hearts[4].gameObject.SetActive(false);
            hearts[5].gameObject.SetActive(false);
            hearts[6].gameObject.SetActive(false);
            hearts[7].gameObject.SetActive(false);
            hearts[8].gameObject.SetActive(false);
            hearts[9].gameObject.SetActive(false);
            hearts[10].gameObject.SetActive(false);
            hearts[11].gameObject.SetActive(false);
            
        }
        else if (life < 3)
        {
            hearts[2].gameObject.SetActive(false);
            hearts[3].gameObject.SetActive(false);
            hearts[4].gameObject.SetActive(false);
            hearts[5].gameObject.SetActive(false);
            hearts[6].gameObject.SetActive(false);
            hearts[7].gameObject.SetActive(false);
            hearts[8].gameObject.SetActive(false);
            hearts[9].gameObject.SetActive(false);
            hearts[10].gameObject.SetActive(false);
            hearts[11].gameObject.SetActive(false);
            
        }
        else if (life < 4)
        {
            hearts[3].gameObject.SetActive(false);
            hearts[4].gameObject.SetActive(false);
            hearts[5].gameObject.SetActive(false);
            hearts[6].gameObject.SetActive(false);
            hearts[7].gameObject.SetActive(false);
            hearts[8].gameObject.SetActive(false);
            hearts[9].gameObject.SetActive(false);
            hearts[10].gameObject.SetActive(false);
            hearts[11].gameObject.SetActive(false);
            
        }
        else if (life < 5)
        {
            hearts[4].gameObject.SetActive(false);
            hearts[5].gameObject.SetActive(false);
            hearts[6].gameObject.SetActive(false);
            hearts[7].gameObject.SetActive(false);
            hearts[8].gameObject.SetActive(false);
            hearts[9].gameObject.SetActive(false);
            hearts[10].gameObject.SetActive(false);
            hearts[11].gameObject.SetActive(false);
            
        }
        else if (life < 6)
        {
            hearts[5].gameObject.SetActive(false);
            hearts[6].gameObject.SetActive(false);
            hearts[7].gameObject.SetActive(false);
            hearts[8].gameObject.SetActive(false);
            hearts[9].gameObject.SetActive(false);
            hearts[10].gameObject.SetActive(false);
            hearts[11].gameObject.SetActive(false);
            
        }
        else if (life < 7)
        {
            hearts[6].gameObject.SetActive(false);
            hearts[7].gameObject.SetActive(false);
            hearts[8].gameObject.SetActive(false);
            hearts[9].gameObject.SetActive(false);
            hearts[10].gameObject.SetActive(false);
            hearts[11].gameObject.SetActive(false);  
        }
        else if (life < 8)
        {
            hearts[7].gameObject.SetActive(false);
            hearts[8].gameObject.SetActive(false);
            hearts[9].gameObject.SetActive(false);
            hearts[10].gameObject.SetActive(false);
            hearts[11].gameObject.SetActive(false);  
        }
        else if (life < 9)
        {
            hearts[8].gameObject.SetActive(false);
            hearts[9].gameObject.SetActive(false);
            hearts[10].gameObject.SetActive(false);
            hearts[11].gameObject.SetActive(false);  
        }
        else if (life < 10)
        {
            hearts[9].gameObject.SetActive(false);
            hearts[10].gameObject.SetActive(false);
            hearts[11].gameObject.SetActive(false);  
        }
        else if (life < 11)
        {
            hearts[10].gameObject.SetActive(false);
            hearts[11].gameObject.SetActive(false);  
        }
        else if (life < 12)
        {
            hearts[11].gameObject.SetActive(false);  
        }
        
        if(life <= 0 && canDie == true)
        {
            myCollider.enabled = false;
            canDie = false;
            //Destroy(Movement);
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
            life += 2;
            hearts[life-2].gameObject.SetActive(true);
            hearts[life-1].gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spike") && life > 0 && canTakeDamage == true)
        {
            canTakeDamage = false; 
            StartCoroutine(hit());
        }

        if (other.CompareTag("Spike1") && life > 0 && canTakeDamage == true)
        {
            canTakeDamage = false; 
            StartCoroutine(hit1());
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
