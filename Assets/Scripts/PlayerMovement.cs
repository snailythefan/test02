using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	//speed of the character movement and the height of the jump. Set these values in the inspector
	public float speed;
	public float jumpHeight;

	//for the animations
	public Animator playerAnimator;
	public SpriteRenderer playerSprite;

	//assigning a variable where we store the rigidbody 2d component
	private Rigidbody2D rb;

	//for jumping once
	private bool onFloor;
	private bool canJump;

	//sound of jump
	public AudioSource JumpPing;

    // Start is called before the first frame update
    void Start()
    {
        //here we store the Rigidbody 2D information into our variable
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //floor check, to see if we can jump
        if (onFloor == true)
        {
        	canJump = true;
        }
        //to stop infinite jump
        else
        {
        	canJump = false;
        }

        //If we're able to jump and we press Space bar, then we jump!
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
        	rb.velocity = Vector2.up * jumpHeight;

        	//for the animations
        	if (playerAnimator != null)
        	{
        		playerAnimator.SetTrigger("jump");
        	}


        	//we play the jump sound
        	JumpPing.Play();
        	Debug.Log("jumped!");
        }

        //code for left and right movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
        	rb.velocity = new Vector2(-speed, rb.velocity.y);

        	//animator stuff
        	if(playerSprite != null)
        	{
        		playerSprite.flipX = true;
        	}
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
        	rb.velocity = new Vector2(+speed, rb.velocity.y);

        	//animator stuff
        	if(playerSprite != null)
        	{
        		playerSprite.flipX = false;
        	}
        }
        else //if we're not pressing an arrow key,
        //our velocity is 0 along the X axis and our Y velocity is determined by the Jump
        {
        	rb.velocity = new Vector2(0,rb.velocity.y);
        }

        //after we've checked everything, we activate the animations
        //magnitude is turning the Vector2 into a number
        //wrap this code inside a statement, so if you don't have an
        //animator then it won't give you a problem

        if(playerAnimator != null)
        {
        	playerAnimator.SetFloat("speed", rb.velocity.magnitude);
        }

    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
    	//if we collide with an object tagged "floor" then our jump resets and we can jump
    	if(collision.gameObject.tag == "floor")
    	{
    		onFloor = true;
    		print("on Floor?:" + onFloor);
    	}
    }

    private void OnCollisionExit2D (Collision2D collision)
    {
    	if(collision.gameObject.tag == "floor")
    	{
    		onFloor = false;
    		print("on Floor?:" + onFloor);
    	}
    }

}
