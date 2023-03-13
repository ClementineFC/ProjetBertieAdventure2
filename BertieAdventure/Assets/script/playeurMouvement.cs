using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeurMouvement : MonoBehaviour
{

    public Vector3 jumpMovement;
    public Vector3 userInput;

    private float vertical,horizontal,jump;
    public float vitesseRotateCamera;
    public float gravity;
    public float turn;
    public float directionY;
    public float playeurSpeed;
    public float jumpSpeed;

    private CharacterController charCon;
    public Animator animatorPerso;

    public bool charIsGrounded;

    // Start is called before the first frame update
    void Start()
    {
        gravity = 49.81f;
        vitesseRotateCamera = 200.0f;
        jumpSpeed = 8.0f;
        playeurSpeed = 6.0f;
        charCon = GetComponent<CharacterController>();
        animatorPerso = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Jump");
        //animatorPerso.SetBool("walk",true);
        animatorPerso.SetBool("jump",false);
        animatorPerso.SetFloat("AxisH", horizontal);
        animatorPerso.SetFloat("AxisV", vertical);
        animatorPerso.SetFloat("Turn", turn);
        turn = Input.GetAxis("Mouse X");

        if (Mathf.Abs(horizontal) >= 0.01f || Mathf.Abs(vertical) >= 0.01f)
        {
            animatorPerso.SetBool("walk", true);
        }
        else
        {
            animatorPerso.SetBool("walk", false);
        }
        //Rotation de la camera avec la souris
        transform.Rotate(0,turn * vitesseRotateCamera * Time.deltaTime, 0);
        userInput = new Vector3(horizontal, 0,  vertical);
        userInput = transform.TransformDirection(userInput);
        userInput = userInput * playeurSpeed;
        directionY = directionY - gravity * Time.deltaTime;
        if (directionY <= -1.0f)
        {
            directionY = -1.0f;
        }
        Physics.SyncTransforms();
        userInput.y = directionY;

        charCon.Move(userInput* Time.deltaTime);
   
        if (Input.GetAxis("Jump") >= 0.1f)
        {
            directionY = jumpSpeed;
            jumpMovement = new Vector3(0.0f,0.2f, 0.0f);
            //gravity = 100000000.0f;
            charCon.Move(jumpMovement);  
        }
        charIsGrounded = charCon.isGrounded;
        if (charIsGrounded == false)
        {
            animatorPerso.SetBool("jump", true);
        }
        
       
        
    }
    void handleMovement()
    {

    }
}
