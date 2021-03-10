using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public int life;
    // Update is called once per frame
    void Update()
    {
        if(life < 1)
        {
            Destroy(hearts[0].gameObject);
        } 
        else if (life < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if (life < 3)
        {
            Destroy(hearts[2].gameObject);
        }
        else if (life < 4)
        {
            Destroy(hearts[3].gameObject);
        }
        else if (life < 5)
        {
            Destroy(hearts[4].gameObject);
        }
        else if (life < 6)
        {
            Destroy(hearts[5].gameObject);
        }
        if(life <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    
        }
    }

    public void TakeDamage(int d) {
        {
            life -= d;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spike"))
        {
            TakeDamage(1);
        }
    }
}
