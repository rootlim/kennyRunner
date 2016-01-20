using UnityEngine;
using System.Collections;

public class charactorController : MonoBehaviour {

    private float inputDirection;
    private float verticalVelocity;


    private Vector2 moveVector;
    private Vector2 lastMotion;
    private CharacterController controller;
    
    private bool facingRight;

    private GameObject playerSprite;

    private float jumpForce = 10f;

    private float gravity = 30f;
    private float speed = 5f;
    private bool sendJumpAvail = false;

    private bool keypressJump = false;
    private bool keypressStop = false;

    private Vector2 startPosition;
    public bool gameOver = false;

    public void keyJump()
    {
        keypressJump = true;
    }

    public void keyStop()
    {
        keypressStop = true;
    }
    public void keyGo()
    {
        keypressStop = false;
    }
    
    // Reference to the player's animator component.
    private Animator anim;


    IEnumerator TranStateToMove(float waitTime,int val,int val2)
    {
        anim.SetInteger("info", val);
        yield return new WaitForSeconds(waitTime);
        anim.SetInteger("info", val2);
    }

    void Awake()
    {
        startPosition = new Vector2(-157, 3);
        // Setting up references.
        playerSprite = transform.FindChild("PlayerSprite").gameObject;
        anim = (Animator)playerSprite.GetComponent(typeof(Animator));
    }

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
       
        
        if (gameOver)
        {
            return;
        }


        /// Player  Dead~
        if (transform.position.y < -1f && transform.position.y > -2f)
        {
            gameOver = true;

            // 일단주석.
            //
            
        }


        moveVector = Vector2.zero;
        float move = Input.GetAxis("Horizontal");

        if (keypressStop)
        {
            move = 0f;
            return;
        }
        else
        {
            move = 1f;
        }


        if (IsControllerGrounded())
        {
            verticalVelocity = 0;
            if (keypressJump)
            {
                keypressJump = false;
                // make the player jump
                verticalVelocity = jumpForce;
                sendJumpAvail = true;
             
                // 점프 에니
             
                anim.SetInteger("info", 1);
            }

            inputDirection = move * speed;
            moveVector.x = inputDirection;

        }
        else
        {
            if (keypressJump)
            {
                keypressJump = false;
                if (sendJumpAvail)
                {
                    // make the player jump
                    verticalVelocity = jumpForce;
                    sendJumpAvail = false;
                 
                    //    SetState(State.JUMP);
                    // 점프 에니
                   StartCoroutine(TranStateToMove(0.1f,0,1));
                   // anim.SetInteger("info", 1);
                }

            }
            verticalVelocity -= gravity * Time.deltaTime;
            moveVector.x = lastMotion.x;
        }

        moveVector.y = verticalVelocity;


        if (moveVector.x > 0 && facingRight)
        {
            Flip();
        }
        else if (moveVector.x < 0 && !facingRight)
        {
            Flip();
        }

        //moveVector = new  (inputDirection, verticalVelocity);
        controller.Move(moveVector * Time.deltaTime);
        lastMotion = moveVector;

	}

    public void ReStartPlay()
    {
        transform.position = startPosition;
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = playerSprite.transform.localScale;
        theScale.x *= -1;
        playerSprite.transform.localScale = theScale;
    }

    private bool IsControllerGrounded()
    {


        Vector2 leftRayStart;
        Vector2 rightRayStart;

        leftRayStart = controller.bounds.center;
        rightRayStart = controller.bounds.center;

        leftRayStart.x -= controller.bounds.extents.x;
        rightRayStart.x += controller.bounds.extents.x;

        Debug.DrawRay(leftRayStart, Vector2.down, Color.red);
        Debug.DrawRay(rightRayStart, Vector2.down, Color.green);

        if (Physics.Raycast(leftRayStart, Vector2.down, (controller.height / 2) + 0.2f))
        {
         
            anim.SetInteger("info", 0);
            return true;
        }

        if (Physics.Raycast(rightRayStart, Vector2.down, (controller.height / 2) + 0.2f))
        {
         
            anim.SetInteger("info", 0);
            return true;
        }



        return false;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        //벽타기.
        /*
        if (controller.collisionFlags == CollisionFlags.Sides)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.DrawRay(hit.point, hit.normal, Color.red, 2.0f);
                moveVector = hit.normal * speed;
                verticalVelocity = jumpForce;
                sendJumpAvail = true;
               // anim.SetInteger("info", 1);
            }
        }
        */

//        Debug.Log(hit.gameObject.tag);
        /*
        switch (hit.gameObject.tag)
        {
            case "COIN":
                Destroy(hit.gameObject);
                coinManager.coin += 1;
                break;
            case "BIGCOIN":
                Destroy(hit.gameObject);
                coinManager.coin += 10;
                break;
            case "DEAD":              
                break;
            default:
                break;
        }
        */
       

    }
    private ShowPanels showPanels;
}
