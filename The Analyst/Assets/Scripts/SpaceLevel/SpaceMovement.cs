using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SpaceMovement : MonoBehaviour { 

      public Rigidbody2D rb2D;
      private bool FaceRight = false; // determine which way player is facing. 
      public static float runSpeed = 10f; 
      public float startSpeed = 10f;
      public bool isAlive = true; 
      //public AudioSource WalkSFX;
      private Vector3 hMove; 
      //private bool isSwimming = false;
      public float spaceSpeed = 5f;
      public float spaceGravity = 0f;
      // public float spaceDrag = 2f;
      // public float spaceAngularDrag = 1f;
      public Animator animator;
      public float originalDrag;
      public float originalAngularDrag;
      private Transform playerArt;

      void Start(){
           animator = gameObject.GetComponentInChildren<Animator>();
           rb2D = transform.GetComponent<Rigidbody2D>();
           playerArt = transform.Find("PlayerArt");

      //      originalDrag = rb2D.drag;
      //             originalAngularDrag = rb2D.angularDrag;
      //             rb2D.drag = spaceDrag;
      //             rb2D.angularDrag = spaceAngularDrag;
                  rb2D.gravityScale = spaceGravity;
      }

    //   void OnTriggerEnter2D(Collider2D other)
    //   {
    //         if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
    //         {
    //               isSwimming = true;
    //               animator.SetBool("isSwimming", isSwimming);
    //               originalDrag = rb2D.drag;
    //               originalAngularDrag = rb2D.angularDrag;
    //               rb2D.drag = swimDrag;
    //               rb2D.angularDrag = swimAngularDrag;
    //               rb2D.gravityScale = swimGravity;
    //         }
    //   }

    //   void OnTriggerExit2D(Collider2D other)
    //   {
    //         if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
    //         {
    //               isSwimming = false;
    //               animator.SetBool("isSwimming", isSwimming);
    //               rb2D.drag = originalDrag;
    //               rb2D.angularDrag = originalAngularDrag;
    //               rb2D.gravityScale = 1;
    //         }
    //   }

      void FixedUpdate(){
            //NOTE: Horizontal axis: [a] / left arrow is -1, [d] / right arrow is 1 
           //hMove = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

           if (isAlive == true) {
                  //transform.position = transform.position + hMove * runSpeed * Time.deltaTime;
                  if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
                        GetComponent<Rigidbody2D> ().AddForce (new Vector2(1.5f, 0f));
                  }
                  if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
                        GetComponent<Rigidbody2D> ().AddForce (new Vector2(-1.5f, 0f));
                  }
                  if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
                        GetComponent<Rigidbody2D> ().AddForce (new Vector2(0f, 1.5f));
                  }
                  if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
                        GetComponent<Rigidbody2D> ().AddForce (new Vector2(0f, -1.5f));
                  }

                  if (Input.GetAxis("Horizontal") != 0 || (Input.GetAxis("Vertical") != 0)){ 
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

            if ((hMove.x <0 && !FaceRight) || (hMove.x >0 && FaceRight)) {
                  playerTurn();
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
