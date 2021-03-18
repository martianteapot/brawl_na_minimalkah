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
    public float moveSpeed = 6f;
    public float rotateSpeed = 10f;
    Rigidbody rb;
    float vertical;
    float horizontal;
    [SerializeField]
    Vector3 moveDirection;
    float inputAmount;
    float slopeAmount;
    Vector3 floorNormal;
    public float slopeInfluence = 5f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();  
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    
    private void Update()
    {
        // reset movement
        moveDirection = Vector3.zero;
        // get vertical and horizontal movement input (controller and WASD/ Arrow Keys)
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");




        Vector3 correctedVertical = vertical * Camera.main.transform.forward;
        Vector3 correctedHorizontal = horizontal * Camera.main.transform.right;
        Vector3 combinedInput = correctedHorizontal + correctedVertical;
        // make sure the input doesnt go negative or above 1;
        float inputMagnitude = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
        inputAmount = Mathf.Clamp01(inputMagnitude);

        moveDirection = new Vector3((combinedInput).normalized.x, 0, (combinedInput).normalized.z);


        
    }
    
    
    
    
    void FixedUpdate()
    {
        Vector3 targetDirNormal = moveDirection;
        targetDirNormal.y = 0;
        Quaternion rot = Quaternion.LookRotation(targetDirNormal);
        Quaternion targetRotation = Quaternion.Slerp(transform.rotation, rot, Time.fixedDeltaTime * inputAmount * rotateSpeed);
        transform.rotation = targetRotation;
        rb.velocity = (moveDirection * GetMoveSpeed() * inputAmount); //+ gravity;
        
        if(moveDirection.x != 0 || moveDirection.z != 0)
        {
            anim.SetBool("isRunning", true);
            playerAudioSource.Play();
        }
        if(moveDirection.x == 0 && moveDirection.z == 0)
        {
            anim.SetBool("isRunning", false);
            playerAudioSource.Stop();
        }

        /*if(joystick.Horizontal == 0 || joystick.Vertical == 0)
        {
            anim.SetBool("isRunning", false);
            //transform.Translate(Vector3.zero);
            playerAudioSource.Play();
        } 
        if(joystick.Horizontal > 0 || joystick.Horizontal < 0 || joystick.Vertical > 0 || joystick.Vertical < 0)
        {
            PlayerSprite.position = new Vector3(joystick.Horizontal + transform.position.x, 1.1f, joystick.Vertical + transform.position.z);
            transform.LookAt(new Vector3(PlayerSprite.position.x, 0, PlayerSprite.position.z));
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0); 
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            anim.SetBool("isRunning", true);
            
        }*/

        
    }

    float GetMoveSpeed()
    {
        // you can add a run here, if run button : currentMovespeed = runSpeed;
        float currentMovespeed = Mathf.Clamp(moveSpeed + (slopeAmount * slopeInfluence), 0, moveSpeed + 1);
        return currentMovespeed;
    }
}
