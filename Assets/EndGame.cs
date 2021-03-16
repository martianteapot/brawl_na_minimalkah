using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
{
   if (other.CompareTag("Player"))
   {
      SceneManager.LoadScene(0);
   }
}
}