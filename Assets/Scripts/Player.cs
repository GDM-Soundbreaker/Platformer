using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//add extra using statement to use scene management functins
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    //designer variables
    public float speed = 10;
    public float jumpSpeed = 10;
    public Rigidbody2D physicsBody;
    public string horizontalAxis = "Horizontal";
    public string jumpButton = "Jump";
    public SpriteRenderer playerSprite; 
    public Animator playerAnimator;
    public Collider2D playerCollider;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get axis input from unity
        float leftRight = Input.GetAxis(horizontalAxis);


        //create direction vector from axis input
        Vector2 direction = new Vector2(leftRight, 0);

        //make direction vector length 1
        direction = direction.normalized;

        //calculate velocity
        Vector2 velocity = direction * speed;
        velocity.y = physicsBody.velocity.y;

        //give the velocity to the rigidbody
        physicsBody.velocity = velocity;



        //tell the animator our speed
        playerAnimator.SetFloat("WalkSpeed", Mathf.Abs(velocity.x) );

        //flip our sprite if we're moving backwards

    if (velocity.x < 0)
        {
            playerSprite.flipX = true;
        }

    else
        {
            playerSprite.flipX = false;
        }
        //Jumping

        //detect if ground is being touched
        //get layer mask from unity using layer name
        LayerMask groundLayerMask = LayerMask.GetMask("Ground");
        //ask the player's collider if we are touching the layermask
        bool touchingGround = playerCollider.IsTouchingLayers(groundLayerMask);


        bool jumpButtonPressed = Input.GetButtonDown(jumpButton);
        if (jumpButtonPressed == true && touchingGround == true)
        {
            //we have pressed jump so we should set upward velocity to jump speed
            velocity.y = jumpSpeed;

            //give the velocity to the rigidbody
            physicsBody.velocity = velocity;
        }


    }

    //Our own function for handling player death
    public void Kill()
    {
        //Reset the current level to restart from beginning
        //1. Ask Unity what current level is
        Scene currentLevel = SceneManager.GetActiveScene();

        //2. Tell unity to load current again by passing build index of level
        SceneManager.LoadScene(currentLevel.buildIndex);
    }

}
