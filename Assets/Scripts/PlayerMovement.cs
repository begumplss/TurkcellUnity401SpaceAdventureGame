using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;

    Vector2 velocity;

    [SerializeField]
    float hiz = default;

    
    [SerializeField]
    float hizlanma = default;

    
    [SerializeField]
    float yavaslama = default;

    [SerializeField]
    float jumpingPower = default;

    float JumpLimit =3;

    int CountJump;

    Joystick joystick;
    JoystickJumpingButton joystickJumpingButton;

    bool JumpingStill;




    // Start is called before the first frame update
    void Start()
    {
        joystickJumpingButton = FindObjectOfType<JoystickJumpingButton>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystick=FindAnyObjectByType<Joystick>();
        
    }

    // Update is called once per frame
    void Update()
    {
    #if UNITY_EDITOR
       ControlKlavye();
    #else
       JoystickControl();
    #endif

    
    }

    void ControlKlavye(){
        float hareketInput = Input.GetAxisRaw("Horizontal");
        Vector2 scale = transform.localScale;

        if(hareketInput>0) { //Hareket ınputa göre değişicek,  
            velocity.x= Mathf.MoveTowards(velocity.x, hareketInput*hiz, hizlanma*Time.deltaTime);
            animator.SetBool("Walk", true);
             GetComponent<SpriteRenderer>().flipX = false;  // Karakteri sağa çevir
        }else if (hareketInput<0){
             velocity.x= Mathf.MoveTowards(velocity.x, hareketInput*hiz, hizlanma*Time.deltaTime);
             animator.SetBool("Walk", true);
             GetComponent<SpriteRenderer>().flipX = true;  // Karakteri sola çevir
        }else {
            velocity.x=Mathf.MoveTowards(velocity.x,0,yavaslama*Time.deltaTime);
            animator.SetBool("Walk", false );
        }

          
        transform.localScale=scale;        
        gameObject.transform.Translate(velocity*Time.deltaTime); 

        if(Input.GetKeyDown("space")){
            StarJumping();

        }

        if(Input.GetKeyUp("space")){
            stopJumping();

        }
    }

    void JoystickControl(){
        float hareketInput=joystick.Horizontal;
         Vector2 scale = transform.localScale;

        if(hareketInput>0) { //Hareket ınputa göre değişicek,  
            velocity.x= Mathf.MoveTowards(velocity.x, hareketInput*hiz, hizlanma*Time.deltaTime);
            animator.SetBool("Walk", true);
             GetComponent<SpriteRenderer>().flipX = false;  // Karakteri sağa çevir
        }else if (hareketInput<0){
             velocity.x= Mathf.MoveTowards(velocity.x, hareketInput*hiz, hizlanma*Time.deltaTime);
             animator.SetBool("Walk", true);
             GetComponent<SpriteRenderer>().flipX = true;  // Karakteri sola çevir
        }else {
            velocity.x=Mathf.MoveTowards(velocity.x,0,yavaslama*Time.deltaTime);
            animator.SetBool("Walk", false );
        }

          
        transform.localScale=scale;        
        gameObject.transform.Translate(velocity*Time.deltaTime); 

        if(joystickJumpingButton.clickonbutton==true&&JumpingStill== false){
          //   Debug.Log("zıplama basıldı");
            JumpingStill = true;
            StarJumping();
        }
         if(joystickJumpingButton.clickonbutton==false&&JumpingStill==true){
            JumpingStill=false;
            stopJumping();
        }
    }



    void StarJumping(){
        if(CountJump<JumpLimit){
           FindObjectOfType<SoundsControl>().JumpingSound();
           rb2d.AddForce(new Vector2(0,jumpingPower),ForceMode2D.Impulse);
           animator.SetBool("Jump",true);
           FindAnyObjectByType<SliderControl>().SliderValue((int)JumpLimit , (int)CountJump);

        }
       
      }
      void stopJumping(){

        animator.SetBool("Jump",false);
        CountJump++;
        FindAnyObjectByType<SliderControl>().SliderValue((int)JumpLimit , (int)CountJump);

      }

      public void ResetJumping(){
        CountJump=0;
        FindAnyObjectByType<SliderControl>().SliderValue((int)JumpLimit , (int)CountJump);

       // Debug.Log("Ziplama Sifirlandi");
      }
      void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag=="Dead"){
            FindObjectOfType<GameControl>().GameOver();
        }
      }

      public void GameOver(){
        Destroy(gameObject);
      }

    
}
