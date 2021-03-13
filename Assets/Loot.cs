using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public GameObject[] loots;
    public int wealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(wealth > 0)
        {
            loots[0].gameObject.SetActive(true);
        }        
        if(wealth > 1)
        {
            loots[1].gameObject.SetActive(true);
        } 
        if(wealth > 2)
        {
            loots[2].gameObject.SetActive(true);
        } 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Loot"))
        {
            wealth += 1;
            other.gameObject.SetActive(false);
        }
    }

}
