using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameControl : MonoBehaviour
{
    public GameObject Pause;
    public GameObject ClickPause;

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        OffPause ();        
    }

    public void GuitToMenu()
    {
        SceneManager.LoadScene(0);  
        OffPause ();      
    }

    public void OnPause () {
        Time.timeScale = 0;
        Pause.SetActive(true);
        ClickPause.SetActive(false);
  
    }
    public void OffPause () {
        Time.timeScale = 1;
        Pause.SetActive(false);
        ClickPause.SetActive(true);
        
    }  

}
