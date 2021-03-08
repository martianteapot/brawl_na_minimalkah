using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] gameObjects;
    public GameObject spawnPos;
    [SerializeField]
    private float timeBtwChange;
    public float startTimeBtwChange;
    
    // Update is called once per frame
    void Update()
    {
        int spawnIndex = Random.Range(0, gameObjects.Length);
        if(timeBtwChange <= 0)
        {
            GameObject item = Instantiate(gameObjects[spawnIndex], spawnPos.transform.position, spawnPos.transform.rotation);
            timeBtwChange = startTimeBtwChange;
        }
        else
        {
            timeBtwChange -= Time.deltaTime;
        }
    }
}