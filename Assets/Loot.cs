using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loot : MonoBehaviour
{
    public GameObject[] loots;
    public int wealth;
    private int mineWealth;
    private int lootInmine;
    public Text mineText;
    // Start is called before the first frame update
    void Start()
    {
        lootInmine = 10;
        mineWealth = 0;
        mineText.text = string.Format("{0}/{1}", mineWealth, lootInmine);    
    }

    // Update is called once per frame
    void Update()
    {
        if(wealth == 0)
        {
            loots[0].gameObject.SetActive(false);
            loots[1].gameObject.SetActive(false);
            loots[2].gameObject.SetActive(false);
        } 
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

        if (other.CompareTag("Trolley") && mineWealth < lootInmine)
        {
            mineWealth += wealth;
            if(mineWealth > lootInmine)
            {
               mineWealth = lootInmine; 
            }
            mineText.text = string.Format("{0}/{1}", mineWealth, lootInmine); 
            wealth = 0;
        }
    }

}
