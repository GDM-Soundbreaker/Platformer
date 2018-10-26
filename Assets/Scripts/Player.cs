using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //designer variables
    public float speed = 10;
    public Rigidbody2D physicsBody;
    public string horizontalAxis = "Horizontal";
    public SpriteRenderer playerSprite; 
    public Animator playerAnimator; 

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
    }


}
