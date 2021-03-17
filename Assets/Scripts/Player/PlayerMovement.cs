using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Joystick joystick;

    [SerializeField]
    Transform PlayerSprite;
    
    public AudioSource playerAudioSource;
    private Animator anim;
    private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();  
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         

        if(joystick.Horizontal == 0 || joystick.Vertical == 0)
        {
            anim.SetBool("isRunning", false);
            transform.Translate(Vector3.zero);
            //playerAudioSource.Play();
        } 
        
        /*if(joystick.Horizontal > 0 || joystick.Horizontal < 0 || joystick.Vertical > 0 || joystick.Vertical < 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            anim.SetBool("isRunning", true);
        }*/

        
        
        if(joystick.Horizontal > 0 || joystick.Horizontal < 0 || joystick.Vertical > 0 || joystick.Vertical < 0)
        {
            PlayerSprite.position = new Vector3(joystick.Horizontal + transform.position.x, 1.1f, joystick.Vertical + transform.position.z);
            transform.LookAt(new Vector3(PlayerSprite.position.x, 0, PlayerSprite.position.z));
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0); 
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            anim.SetBool("isRunning", true);
            
        }
        

        /*  if(joystick.enabled == false)
        {
            transform.Translate(Vector3.zero);
        }
        */

        
    }
}
