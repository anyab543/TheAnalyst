using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour { 

      public Rigidbody2D rb2D;
      private bool FaceRight = false; // determine which way player is facing. 
      public static float runSpeed = 10f; 
      public float startSpeed = 10f;
      public bool isAlive = true; 
      //public AudioSource WalkSFX;
      private Vector3 hMove; 
      private bool isSwimming = false;
      public float swimSpeed = 5f;
      public float swimGravity = 1f;
      public float swimDrag = 2f;
      public float swimAngularDrag = 1f;
      public Animator animator;
      public float originalDrag;
      public float originalAngularDrag;
      private Transform playerArt;

      void Start(){
           animator = gameObject.GetComponentInChildren<Animator>();
           rb2D = transform.GetComponent<Rigidbody2D>();
           playerArt = transform.Find("PlayerArt");
      }

      void OnTriggerEnter2D(Collider2D other)
      {
            if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
            {
                  isSwimming = true;
                  animator.SetBool("isSwimming", isSwimming);
                  originalDrag = rb2D.drag;
                  originalAngularDrag = rb2D.angularDrag;
                  rb2D.drag = swimDrag;
                  rb2D.angularDrag = swimAngularDrag;
                  rb2D.gravityScale = swimGravity;
            }
      }

      void OnTriggerExit2D(Collider2D other)
      {
            if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
            {
                  isSwimming = false;
                  animator.SetBool("isSwimming", isSwimming);
                  rb2D.drag = originalDrag;
                  rb2D.angularDrag = originalAngularDrag;
                  rb2D.gravityScale = 1;
            }
      }

      void Update(){
            //NOTE: Horizontal axis: [a] / left arrow is -1, [d] / right arrow is 1 
           hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
           if (isAlive == true && !isSwimming) {
                  transform.position = transform.position + hMove * runSpeed * Time.deltaTime;

                  if (Input.GetAxis("Horizontal") != 0){ 
                        animator.SetBool ("isWalking", true); 
                  //       if (!WalkSFX.isPlaying){ 
                  //             WalkSFX.Play(); 
                  //      } 
                  } 
                  else { 
                        animator.SetBool ("isWalking", false); 
                  //      animator.SetBool ("Walk", false); 
                  //      WalkSFX.Stop(); 
                  } 

                  // Turning: Reverse if input is moving the Player right and Player faces left 

            }

            else if (isSwimming && isAlive)
            {
                  // Get input for swimming movement
                  float moveHorizontal = Input.GetAxis("Horizontal");
                  float moveVertical = Input.GetAxis("Vertical");

                  // Set the player's velocity based on input
                  Vector2 movement = new Vector2(moveHorizontal, moveVertical);
                  rb2D.velocity = movement * swimSpeed;
            }

            if ((hMove.x <0 && !FaceRight) || (hMove.x >0 && FaceRight)) {
                  playerTurn();
            } 
      } 

      void FixedUpdate(){
            //slow down on hills / stops sliding from velocity
            if (hMove.x == 0){
                  rb2D.velocity = new Vector2(rb2D.velocity.x / 1.1f, rb2D.velocity.y) ;
            }
      } 

      void playerTurn()
      {
            // NOTE: Switch player facing label
            FaceRight = !FaceRight;

            // NOTE: Multiply player's x local scale by -1.
            Vector3 theScale = playerArt.localScale;
            theScale.x *= -1;
            playerArt.localScale = theScale;
      }

}
